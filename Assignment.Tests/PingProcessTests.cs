﻿using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    public PingProcess Sut { get; set; } = new();

    private static readonly string[] NewLineArray = { Environment.NewLine };

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "-c 4 localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("-c 4 google.com").ExitCode;
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
        PingResult result = Sut.Run("-c 4 localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {

        // Act
        var resultTask = Sut.RunTaskAsync("-c 4 localhost");
        resultTask.Wait();
        
        var result = resultTask.Result;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.ExitCode == 0);
        Assert.IsTrue(result.ExitCode == 0); 
        Assert.IsNotNull(result.StdOutput);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.

        // Arrange
        string expectedHost = "-c 4 localhost";

        // Act
        Task<PingResult> task = Sut.RunAsync(expectedHost);
        PingResult result = task.Result; // Block synchronously for task completion

        // Assert
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public async Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.

        // Arrange
        string expectedHost = "-c 4 localhost";

        // Act
        PingResult result = await Sut.RunAsync(expectedHost);

        // Assert
        AssertValidPingOutput(result);
    }

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        CancellationTokenSource cancellationTokenSource = new();
        cancellationTokenSource.Cancel();
        Sut.RunAsync("-c 4 localhost", cancellationTokenSource.Token).Wait();
    }

    [TestMethod]
    public async Task RunAsync_MultipleHosts_ReturnsCombinedResults()
    {
        // Arrange
        PingProcess newPingProcess = new ();
        var hostNames = new List<string> { "-c 4 localhost", "-c 4 127.0.0.1" };
        var cancellationToken = new CancellationTokenSource().Token;

        // Act
        PingResult result = await newPingProcess.RunAsync(hostNames, cancellationToken);

        // Assert
        Assert.IsTrue(result.ExitCode >= 0, "Exit code should be non-negative.");
        Assert.IsFalse(string.IsNullOrEmpty(result.StdOutput), "StdOutput should not be empty.");
        Assert.IsTrue(result.StdOutput.Contains("Reply"), "StdOutput should contain expected ping output.");
    }

    [TestMethod]
    public async Task RunAsync_WithCancellation_ThrowsOperationCanceledException()
    {
        // Arrange
        PingProcess newPingProcess = new();
        var hostNames = new List<string> { "-c 4 localhost", "-c 4 127.0.0.1" };
        var cts = new CancellationTokenSource();
        cts.Cancel(); // Cancel immediately

        // Act & Assert
        await Assert.ThrowsExceptionAsync<AggregateException>(async () =>
        {
            await newPingProcess.RunAsync(hostNames, cts.Token);
        });
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Arrange
        string expectedHost = "-c 4 localhost";
        CancellationTokenSource cts = new();
        cts.Cancel(); // Immediately cancel the token

        // Act
        try
        {
            // Accessing task.Result triggers the AggregateException due to task cancellation
            Sut.RunAsync(expectedHost, cts.Token).Wait();
        }
        catch (AggregateException ex)
        {
            // Flatten the exception to check for the inner TaskCanceledException
            AggregateException flattened = ex.Flatten();
            TaskCanceledException? taskCanceledEx = flattened.InnerExceptions
                .OfType<TaskCanceledException>()
                .FirstOrDefault();

            Assert.IsNotNull(taskCanceledEx);
            throw taskCanceledEx; // Re-throws the TaskCanceledException to satisfy ExpectedException attribute
        }
    }
    
    private static readonly string[] LocalhostArray = { "-c 4 localhost" };
    [TestMethod]
    public async Task RunAsync_MultipleHostAddresses_True()
    {
        // Arrange
        string[] hostNames = { "-c 4 localhost", "-c 4 localhost", "-c 4localhost", "-c 4 localhost" };

        // Dynamically calculate the expected lines per host using actual output
        PingResult singleHostResult = await Sut.RunAsync(LocalhostArray);
        int linesPerHost = singleHostResult.StdOutput?
            .Split(NewLineArray, StringSplitOptions.RemoveEmptyEntries)
            .Length ?? 0;

        int expectedLineCount = linesPerHost * hostNames.Length;

        // Act
        PingResult result = await Sut.RunAsync(hostNames);
        int? actualLineCount = result.StdOutput?
            .Split(NewLineArray, StringSplitOptions.RemoveEmptyEntries)
            .Length;

        // Assert
        Assert.AreEqual(expectedLineCount, actualLineCount, $"Expected {expectedLineCount} lines, but found {actualLineCount}.");
    }

    [TestMethod]
    public async Task RunLongRunningAsync_UsingTpl_Success()
    {
        // Arrange
        var startInfo = new ProcessStartInfo("ping", "-c 4 localhost")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        var cancellationToken = new CancellationTokenSource().Token;

        // Act
        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, cancellationToken);

        // Assert
        Console.WriteLine($"Exit Code: {exitCode}");
        Assert.AreEqual(0, exitCode, "Expected the exit code to be 0 for successful execution.");
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count()+1);
    }


    private readonly string PingOutputLikeExpression = @"
PING * 56 data bytes
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms
64 bytes from * (::1): icmp_seq=* ttl=* time=* ms

--- * ping statistics ---
* packets transmitted, * received, *% packet loss, time *ms
rtt min/avg/max/mdev = */*/*/* ms
".Trim();
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression)??false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}