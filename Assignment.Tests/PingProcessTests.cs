using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Process process = Process.Start("ping", "localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    /*[TestMethod]
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
        // Arrange
        PingProcess pp = new();

        // Act
        Task<PingResult> task = pp.RunTaskAsync("localhost");
        PingResult result = task.Result;

        // Assert
        AssertValidPingOutput(result);
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));

        // Do NOT use async/await in this test.
        // Test Sut.RunTaskAsync("localhost");
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Arrange
        PingResult result = default;

        // Act
        Task task = Sut.RunAsync("localhost").ContinueWith(t => result = t.Result);
        task.Wait();

        // Assert
        AssertValidPingOutput(result);
        Assert.AreEqual(0, result.ExitCode);
    }

    [TestMethod]
    public async Task RunAsync_UsingTpl_Success()
    {
        // Arrange
        PingResult result = await Sut.RunAsync("localhost");

        // Act

        // Assert
        AssertValidPingOutput(result);
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
    }

#pragma warning restore CS1998 // Remove this

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        string hostNames = "localhost";
        CancellationTokenSource cts = new();

        Task task = Task.Run(() =>
        {
            Task<PingResult> result = Sut.RunAsync(hostNames, cts.Token);
            cts.Cancel();
            return result;
        });

        task.Wait();
    }

    [TestMethod]
    public void RunAsync_UsingTplWithCancellation_CatchTaskCanceledException()
    {
        // Arrange
        PingProcess sut = new();
        string hostName = "localhost";
        CancellationTokenSource cts = new();

        // Act
        Task task = Task.Run(() => sut.RunAsync(hostName, cts.Token));
        cts.Cancel(); // Request cancellation

        try
        {
            task.Wait(); // Wait wraps exceptions in AggregateException
            Assert.Fail("Expected TaskCanceledException but no exception was thrown.");
        }
        catch (AggregateException ex)
        {
            // Flatten and validate TaskCanceledException
            AggregateException flattened = ex.Flatten();
            Assert.IsTrue(flattened.InnerExceptions.Any(e => e is TaskCanceledException),
                          "Expected TaskCanceledException in AggregateException.");
        }
    }

    [TestMethod]
    public async Task RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Arrange
        PingProcess sut = new();
        string hostName = "localhost";
        CancellationTokenSource cts = new();

        // Act
        cts.Cancel();

        try
        {
            await sut.RunAsync(hostName, cts.Token);
            Assert.Fail("Expected TaskCanceledException but no exception was thrown.");
        }
        catch (AggregateException ex)
        {
            // Flatten and validate TaskCanceledException
            AggregateException flattened = ex.Flatten();
            Assert.IsTrue(flattened.InnerExceptions.Any(e => e is TaskCanceledException),
                          "Expected TaskCanceledException in AggregateException.");
        }
        catch (TaskCanceledException)
        {
            // This block will be hit directly if the TaskCanceledException is not wrapped in an AggregateException
            Assert.IsTrue(true);
        }
    }

    public PingProcess GetSut()
    {
        return Sut;
    }

    // FOR TYLER -- THIS IS WHERE I STOPPED, I NEED TO WRITE THE NEXT TEST BELOW THIS NOTE.
    // I already started working on implemented the method, but it is not right at all lol.

    [TestMethod]
    public async Task RunAsync_MultipleHostAddresses_True()
    {
        // Arrange
        string[] hostNames = ["localhost", "localhost", "localhost", "localhost"]; // Correct array syntax
        int expectedLineCount = hostNames.Length * PingOutputLikeExpression.Split(Environment.NewLine).Length;

        // Act
        PingResult result = await Sut.RunAsync(hostNames);

        // Assert
        // Split the StdOutput and count the number of lines
        int actualLineCount = result.StdOutput?.Split(Environment.NewLine).Length ?? 0;

        // Validate that the line count matches the expected number of lines
        Assert.AreEqual(expectedLineCount, actualLineCount, "The number of lines in StdOutput does not match the expected count.");
    }

    [TestMethod]
    public async Task RunAsync_MultipleHosts_ReturnsAggregatedOutput()
    {
        // Arrange
        PingProcess pingProcess = new();
        string[] hostnames = ["localhost", "localhost", "localhost"];

        // Act
        PingResult result = await pingProcess.RunAsync(hostnames);

        // Assert
        Assert.IsNotNull(result.StdOutput);
        Assert.IsTrue(result.StdOutput.Contains("Reply from"));
        Assert.AreEqual(0, result.ExitCode);
    }

    [TestMethod]
    public async Task RunLongRunningAsync_ReturnsPingResult()
    {
        // Arrange
        PingProcess sut = new();
        ProcessStartInfo startInfo = new("ping")
        {
            Arguments = "localhost",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
        };

        StringBuilder capturedOutput = new();
        void progressOutput(string? line) => capturedOutput.AppendLine(line);

        CancellationTokenSource cts = new();

        // Act
        PingResult result = await sut.RunLongRunningAsync(startInfo, progressOutput, null, cts.Token);

        // Assert
        AssertValidPingOutput(result);
    }*/

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
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }

    private void AssertValidPingOutput(PingResult result)
    {
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
    }
}