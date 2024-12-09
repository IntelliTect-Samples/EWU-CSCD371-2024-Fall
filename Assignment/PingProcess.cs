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
            (stringBuilder ??= new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);

        string output = stringBuilder?.ToString() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(output))
        {
            output = $"No output captured for host: {hostNameOrAddress}";
        }

        return new PingResult(process.ExitCode, output);
    }


    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return Task.Run(() => Run(hostNameOrAddress));
    }


    public async Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        try
        {
            return await Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                return Run(hostNameOrAddress);
            }, cancellationToken);
        }
        catch (OperationCanceledException ex)
        {
            throw new AggregateException(new TaskCanceledException("Task was canceled.", ex));
        }
    }

    public async Task<PingResult> RunAsync(
        IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    {
        StringBuilder stringBuilder = new();
        var lockObject = new object();

        try
        {
            var pingTasks = hostNameOrAddresses.Select(async host =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                PingResult result = await RunAsync(host, cancellationToken);

                lock (lockObject)
                {
                    if (!string.IsNullOrEmpty(result.StdOutput))
                    {
                        stringBuilder.AppendLine(result.StdOutput.Trim());
                    }
                }

                return result.ExitCode;
            });

            int[] exitCodes = await Task.WhenAll(pingTasks);

            int combinedExitCode = exitCodes.Sum();

            return new PingResult(combinedExitCode, stringBuilder.ToString());
        }
        catch (OperationCanceledException ex)
        {
            throw new AggregateException(new TaskCanceledException("Operation canceled", ex));
        }
    }


    public Task<int> RunLongRunningAsync(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        return Task.Factory.StartNew(() =>
        {

            token.ThrowIfCancellationRequested();

            Process process = RunProcessInternal(startInfo, progressOutput, progressError, token);

            return process.ExitCode;
        },
        token,
        TaskCreationOptions.LongRunning,
        TaskScheduler.Current
        );
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