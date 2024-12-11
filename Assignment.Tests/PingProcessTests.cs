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
    /*
     * NOTE TO ANY COMMENTORS:
     * This isn't complete yet. I'm working on making it so that it uses the wildcard pattern,
     * and doesn't just check for error codes.
     */
    private PingProcess Sut { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "localhost -c 4");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    //[TestMethod]
    //public void Run_GoogleDotCom_Success()
    //{
    //    int exitCode = Sut.Run("google.com -c 4").ExitCode;
    //    Assert.AreEqual<int>(0, exitCode);
    //}

    //[TestMethod]
    //public void Run_InvalidAddressOutput_Success()
    //{
    //    (int exitCode, string? stdOutput) = Sut.Run("badaddress");
    //    Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
    //    stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
    //    Assert.AreEqual<string?>(
    //        "Ping request could not find host badaddress. Please check the name and try again.".Trim(),
    //        stdOutput,
    //        $"Output is unexpected: {stdOutput}");
    //    Assert.AreEqual<int>(1, exitCode);
    //}

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("localhost -c 4");
        //Assert.AreEqual(0, result.ExitCode);
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        // Arrange
        PingProcess pp = new();

        // Act
        Task<PingResult> task = pp.RunTaskAsync("localhost -c 4");
        PingResult result = task.Result;

        // Assert
        //AssertValidPingOutput(result);
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
        Task task = Sut.RunAsync("localhost -c 4").ContinueWith(t => result = t.Result);
        task.Wait();

        // Assert
        //AssertValidPingOutput(result);
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
    }

    [TestMethod]
    public async Task RunAsync_UsingTpl_Success()
    {
        // Arrange
        PingResult result = await Sut.RunAsync("localhost -c 4");

        // Act

        // Assert
        //AssertValidPingOutput(result);
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
    }

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        string hostNames = "localhost -c 4";
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
        string hostName = "localhost -c 4";
        CancellationTokenSource cts = new();

        // Act
        Task task = Task.Run(() => sut.RunAsync(hostName, cts.Token));
        cts.Cancel();

        try
        {
            task.Wait();
            Assert.Fail("Expected TaskCanceledException but no exception was thrown.");
        }
        catch (AggregateException ex)
        {
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
        string hostName = "localhost -c 4";
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
            AggregateException flattened = ex.Flatten();
            Assert.IsTrue(flattened.InnerExceptions.Any(e => e is TaskCanceledException),
                          "Expected TaskCanceledException in AggregateException.");
        }
        catch (TaskCanceledException)
        {
            Assert.IsTrue(true);
        }
    }

    public PingProcess GetSut()
    {
        return Sut;
    }

    [TestMethod]
    public async Task RunAsync_MultipleHostAddresses_True()
    {
        // Arrange
        string[] hostNames = ["localhost -c 4", "localhost -c 4", "localhost -c 4", "localhost -c 4"]; // Correct array syntax

        // Act
        PingResult result = await Sut.RunAsync(hostNames);

        // Assert
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
        Assert.AreEqual(0, result.ExitCode);
    }

    [TestMethod]
    public async Task RunAsync_MultipleHosts_ReturnsAggregatedOutput()
    {
        // Arrange
        PingProcess pingProcess = new();
        string[] hostnames = ["localhost -c 4", "localhost -c 4", "localhost -c 4"];

        // Act
        PingResult result = await pingProcess.RunAsync(hostnames);

        // Assert
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
        Assert.AreEqual(0, result.ExitCode);
    }

    [TestMethod]
    public async Task RunLongRunningAsync_ReturnsPingResult()
    {
        // Arrange
        PingProcess sut = new();
        ProcessStartInfo startInfo = new("ping")
        {
            Arguments = "localhost -c 4",
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
        //AssertValidPingOutput(result);
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
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
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }

    private void AssertValidPingOutput(PingResult result)
    {
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
    }
}