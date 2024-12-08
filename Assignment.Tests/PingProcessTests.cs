using IntelliTect.TestTools;
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
    PingProcess Sut { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "localhost");
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
        PingResult result = Sut.Run("localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {

        // Act
        var resultTask = Sut.RunTaskAsync("localhost");
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
        string expectedHost = "localhost";

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
        string expectedHost = "localhost";

        // Act
        PingResult result = await Sut.RunAsync(expectedHost);

        // Assert
        AssertValidPingOutput(result);
    }

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        Sut.RunAsync("localhost", cancellationTokenSource.Token).Wait();
    }

    [TestMethod]
    public async Task RunAsync_MultipleHosts_ReturnsCombinedResults()
    {
        // Arrange
        PingProcess newPingProcess = new ();
        var hostNames = new List<string> { "localhost", "127.0.0.1", "google.com" };
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
        var hostNames = new List<string> { "localhost", "127.0.0.1", "google.com" };
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
        string expectedHost = "localhost";
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


    
    [TestMethod]
    public async Task RunAsync_MultipleHostAddresses_True()
    {
        // Pseudo Code - don't trust it!!!
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);
    }

    [TestMethod]
    public async Task RunLongRunningAsync_UsingTpl_Success()
    {
        // Arrange
        var startInfo = new ProcessStartInfo("ping", "localhost")
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

    readonly string PingOutputLikeExpression = @"
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
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression)??false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
