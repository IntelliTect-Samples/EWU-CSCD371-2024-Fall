using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder??=new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult( process.ExitCode, stringBuilder?.ToString());
    }

    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return Task.Run(() => Run(hostNameOrAddress));
    }

    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return Task.Run(() => Run(hostNameOrAddress));
    }

    async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    {
        var outputBuilder = new StringBuilder();
        var tasks = new List<Task>();

        var outputLock = new object();

        foreach (var hostNameOrAddress in hostNameOrAddresses)
        {
            tasks.Add(Task.Run(async () =>
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = "ping",
                    Arguments = hostNameOrAddress,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = new Process { StartInfo = processStartInfo };

                try
                {
                    process.Start();

                    var output = await process.StandardOutput.ReadToEndAsync();
                    var error = await process.StandardError.ReadToEndAsync();

                    await process.WaitForExitAsync(cancellationToken);

                    lock (outputLock)
                    {
                        outputBuilder.AppendLine(output);
                        if (!string.IsNullOrWhiteSpace(error))
                        {
                            outputBuilder.AppendLine(error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    lock (outputLock)
                    {
                        outputBuilder.AppendLine($"Error pinging {hostNameOrAddress}: {ex.Message}");
                    }
                }
            }, cancellationToken));
        }

        await Task.WhenAll(tasks);
        return new PingResult(0, outputBuilder.ToString());
    }

    async public Task<PingResult> RunAsync(params string[] hostNameOrAddresses)
    {
        StringBuilder? stringBuilder = null;
        ParallelQuery<Task<int>>? all = hostNameOrAddresses.AsParallel().Select(async item =>
        {
            Task<PingResult> task = null!;
            // ...

            await task.WaitAsync(default(CancellationToken));
            return task.Result.ExitCode;
        });

        await Task.WhenAll(all);
        int total = all.Aggregate(0, (total, item) => total + item.Result);
        return new PingResult(total, stringBuilder?.ToString());
    }

    async public Task<PingResult> RunLongRunningAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        Task task = null!;
        await task;
        throw new NotImplementedException();
    }

    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }

            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}
