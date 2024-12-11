﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    private PingProcess Sut { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "-n 4 localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput) = Sut.Run("badaddress");
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<string?>(
            "Ping request could not find host badaddress. Please check the name and try again.".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(1, exitCode);
    }

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("-n 4 localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        // Do NOT use async/await in this test.
        Task<PingResult> task = Sut.RunTaskAsync("-n 4 localhost");
        task.Wait();
        PingResult result = task.Result;
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public Task RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        Task<PingResult> task = Sut.RunAsync("-n 4 localhost");
        task.Wait();
        PingResult result = task.Result;
        AssertValidPingOutput(result);
        return Task.CompletedTask;
    }

[TestMethod]
async public Task RunAsync_UsingTpl_Success()
{
    // DO use async/await in this test.
    PingResult result = await Sut.RunAsync("-n 4 localhost");

    // Test Sut.RunAsync("localhost");
    AssertValidPingOutput(result);
}
    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()  // I believe this test is incorrect and should be removed. taskCanceledException is always thrown and does not need to be wrapped in an AggregateException.
    {
        using (var cts = new System.Threading.CancellationTokenSource())
        {
            cts.Cancel();
            Task<PingResult> task = Sut.RunAsync("-n 4 localhost", cts.Token);
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is TaskCanceledException)
                {
                    throw new AggregateException(ex.InnerException);
                }
                throw ex.Flatten().InnerException ?? ex;
            }
        }
    }
    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        using (var cts = new System.Threading.CancellationTokenSource())
        {
            cts.Cancel();
            Task<PingResult> task = Sut.RunAsync("-n 4 localhost", cts.Token);
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                throw ex.Flatten().InnerException ?? ex;
            }
        }
    }
    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Length * hostNames.Length;
        List<Task<PingResult>> tasks = hostNames.Select(host => Sut.RunAsync($"-n 4 {host}")).ToList();
        PingResult[] results = await Task.WhenAll(tasks);
        int lineCount = results.Sum(result => result.StdOutput?.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Length ?? 0);
        Assert.AreEqual(expectedLineCount, lineCount);
    }

    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        // Test Sut.RunLongRunningAsync("localhost");  
        ProcessStartInfo startInfo = new("ping", "-n 4 localhost");
        PingResult result = await Sut.RunLongRunningAsync(startInfo, null, null, default);
        AssertValidPingOutput(result);
    }
    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        object lockObject = new();

        numbers.AsParallel().ForAll(item =>
        {
            lock (lockObject)
            {
                stringBuilder.AppendLine("");
            }
        });

        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreEqual(numbers.Count() + 1, lineCount);
    }

    private readonly string PingOutputLikeExpression = @"
Pinging * with 32 bytes of data:
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*
Reply from ::1: time<*

Ping statistics for ::1:
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *".Trim();
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        Console.WriteLine($"stdOutput: {stdOutput}");
        Console.WriteLine($"PingOutputLikeExpression: {PingOutputLikeExpression}");
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
    Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false, $"Output is unexpected: {stdOutput}");
    Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
