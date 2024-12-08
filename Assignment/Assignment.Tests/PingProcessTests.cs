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
    [DataRow("www.google.com")]
    [DataRow("localhost")]
    [DataRow("8.8.8.8")]
    [DataRow("facebook.com")]
    public void RunTaskAsync_Success(string address)
    {

        //Act
        Task<PingResult> task = Sut.RunTaskAsync(address);
        task.Wait();
        //Assert
        Assert.AreEqual(0, task.Result.ExitCode);
    }

    [TestMethod]

    [DataRow("www.google.com")]
    [DataRow("localhost")]
    [DataRow("8.8.8.8")]
    [DataRow("facebook.com")]
    public void RunAsync_UsingTaskReturn_Success(string address)
    {
        //Arrange

        //Act

        Task<PingResult> pingResult = Sut.RunAsync(address);
        pingResult.Wait();
        //Assert
        AssertValidPingOutput(pingResult.Result);

    }

    [TestMethod]
    [DataRow("www.google.com")]
    [DataRow("localhost")]
    [DataRow("8.8.8.8")]
    [DataRow("facebook.com")]
    async public Task RunAsync_UsingTpl_Success(string hostName)
    {
        // Arrange & Act
        Task<PingResult> pingResult = Sut.RunAsync(hostName);
        //Assert
        AssertValidPingOutput(await pingResult);
    }

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        // Arrange
        CancellationToken cancellationToken = new(true);

        // Act
        Task<PingResult> pingResult = Sut.RunAsync("localhost", cancellationToken);
        pingResult.Wait();
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Use exception.Flatten()
        // Arrange
        CancellationToken cancellationToken = new(true);

        // Act
        Task<PingResult> pingResult = Sut.RunAsync("localhost", cancellationToken);

        // Assert
        Assert.ThrowsException<AggregateException>(() => pingResult.Wait()).Flatten().Handle((exception) => throw exception);
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        // Pseudo Code - don't trust it!!!

        // Arrange
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        
        // Act
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        
        // Assert
        Assert.AreEqual(expectedLineCount, lineCount);
    }

    [TestMethod]
#pragma warning disable CS1998 // Remove this
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        PingResult result = default;
        // Test Sut.RunLongRunningAsync("localhost");
        AssertValidPingOutput(result);

    }
#pragma warning restore CS1998 // Remove this

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count() + 1);
    }

    readonly string PingOutputLikeExpression = @"
Pinging * with 32 bytes of data:
Reply from *
Reply from *
Reply from *
Reply from *

Ping statistics for *
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
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
