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

    public async Task<PingResult> RunAsync(string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;

        void updateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);

        Process process = RunProcessInternal(StartInfo, updateStdOutput, null, cancellationToken);

        await Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            process.WaitForExit();
            cancellationToken.ThrowIfCancellationRequested();
        }, cancellationToken);

        return new PingResult(process.ExitCode, stringBuilder?.ToString());
    }

    public async Task<PingResult> RunAsync(string[] hostNameOrAddresses)
    {
        Task<PingResult>[] tasks = hostNameOrAddresses.Select((string x) => RunAsync(x)).ToArray();
        await Task.WhenAll(tasks);

        string aggregatedOutput = string.Join(
            Environment.NewLine,
            tasks.Select(x => x.Result.StdOutput?.Trim() ?? string.Empty)
        );

        return new PingResult(tasks.Max(x => x.Result.ExitCode), aggregatedOutput);
    }

    public Task<PingResult> RunLongRunningAsync(
    ProcessStartInfo startInfo,
    Action<string?>? progressOutput,
    Action<string?>? progressError,
    CancellationToken token)
    {
        return Task.Factory.StartNew(() =>
        {
            token.ThrowIfCancellationRequested();

            StringBuilder outputBuilder = new();
            void CaptureOutput(string? line)
            {
                outputBuilder.AppendLine(line);
                progressOutput?.Invoke(line);
            }

            Process process = RunProcessInternal(startInfo, CaptureOutput, progressError, token);

            process.WaitForExit();

            token.ThrowIfCancellationRequested();

            int exitCode = process.ExitCode;
            string stdOutput = outputBuilder.ToString().Trim();

            return new PingResult(exitCode, stdOutput);
        }, token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
    }

    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        Process process = new()
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