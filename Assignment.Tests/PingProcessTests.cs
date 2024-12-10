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
    public PingProcess Sut { get; set; } = new();

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
        int exitCode = Sut.Run("-c 8.8.8.8").ExitCode;
        Assert.AreEqual<int>(1, exitCode);
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
        Assert.AreEqual(2, exitCode);
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
        // Arrange
        string host = "-c 4 localhost";

        // Act
        Task<PingResult> pingTask = Sut.RunTaskAsync(host);
        pingTask.Wait();

        PingResult result = pingTask.Result;

        // Assert
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsNotNull(result.StdOutput);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        {
            // Arrange
            string host = "-c 4 localhost";

            // Act
            Task<PingResult> pingTask = Sut.RunAsync(host);
            pingTask.Wait();

            PingResult result = pingTask.Result;

            // Assert
            Assert.AreEqual(0, result.ExitCode);
            Assert.IsNotNull(result.StdOutput);
        }
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        // Arrange
        string host = "-c 4 localhost";

        // Act
        PingResult result = await Sut.RunAsync(host);

        // Assert
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsNotNull(result.StdOutput);
    }




    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        // Arrange
        string host = "-c 4 localhost";
        var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act
        Task<PingResult> pingTask = Sut.RunAsync(host, cts.Token);
        pingTask.Wait();
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Arrange
        string host = "-c 4 localhost";
        var cts = new CancellationTokenSource();
        cts.Cancel(); 
        try
        {
            // Act
            Task<PingResult> pingTask = Sut.RunAsync(host, cts.Token);
            pingTask.Wait();
        }
        catch (AggregateException ex)
        {
            var flattened = ex.Flatten();

            // Assert
            if (flattened.InnerException is TaskCanceledException)
            {
                throw flattened.InnerException;
            }
            else
            {
                throw;
            }
        }
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        // Pseudo Code - don't trust it!!!
        string[] hostNames = new string[] { "-c 4 localhost", "-c 4 localhost", "-c 4 localhost", "-c 4 localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);
    }

    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        ProcessStartInfo startInfo = new("ping", "-c 4 localhost");
        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, default);
        Assert.AreEqual(0, exitCode);
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        try
        {
            IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
            System.Text.StringBuilder stringBuilder = new();
            numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
            int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
            Assert.AreNotEqual(lineCount, numbers.Count() + 1);
        }
        catch (AggregateException){}
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
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression)??false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}