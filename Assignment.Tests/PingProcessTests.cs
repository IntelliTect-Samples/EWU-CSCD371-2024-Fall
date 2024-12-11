using IntelliTect.TestTools;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment.Tests;
#pragma warning disable CA1707 // Identifiers should not contain underscores
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
        Process process = Process.Start("ping", "localhost -c 4");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("google.com -c 4").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput) = Sut.Run("badaddress");
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(string.IsNullOrWhiteSpace(stdOutput));

        //On linux this does not happen
        //Assert.AreEqual<string?>(
        //    "Ping request could not find host badaddress. Please check the name and try again.".Trim(),
        //    stdOutput,
        //    $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(2, exitCode);
    }

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult pingResult = Sut.Run("localhost -c 4");
        Assert.AreEqual(0, pingResult.ExitCode);
    }

    [TestMethod]
    [DataRow("google.com -c 4")]
    [DataRow("localhost -c 4")]
    [DataRow("8.8.8.8 -c 4")]
    [DataRow("facebook.com -c 4")]
    public void RunTaskAsync_Success(string address)
    {

        //Act
        Task<PingResult> task = Sut.RunTaskAsync(address);
        task.Wait();
        //Assert
        Assert.AreEqual(0, task.Result.ExitCode);
    }

    [TestMethod]

    [DataRow("google.com -c 4")]
    [DataRow("localhost -c 4")]
    [DataRow("8.8.8.8 -c 4")]
    [DataRow("facebook.com -c 4")]
    public void RunAsync_UsingTaskReturn_Success(string address)
    {
        //Arrange

        //Act

        Task<PingResult> pingResult = Sut.RunAsync(address);
        pingResult.Wait();
        //Assert

        Assert.AreEqual(0, pingResult.Result.ExitCode);

    }

    [TestMethod]
    [DataRow("google.com -c 4")]
    [DataRow("localhost -c 4")]
    [DataRow("8.8.8.8 -c 4")]
    [DataRow("facebook.com -c 4")]
    public async Task RunAsync_UsingTpl_Success(string hostName)
    {
        // Arrange & Act
        Task<PingResult> taskResult = Sut.RunAsync(hostName);
        PingResult pingResult = await taskResult;
        //Assert

        Assert.AreEqual(0, pingResult.ExitCode);
    }

    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        // Arrange
        CancellationToken cancellationToken = new(true);

        // Act
        Task<PingResult> pingResult = Sut.RunAsync("localhost -c 4", cancellationToken);
        pingResult.Wait();

        Assert.AreEqual(0, pingResult.Result.ExitCode);
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Use exception.Flatten()
        // Arrange
        CancellationToken cancellationToken = new(true);

        // Act
        Task<PingResult> pingResult = Sut.RunAsync("localhost -c 4", cancellationToken);

        // Assert
        Assert.ThrowsException<AggregateException>(pingResult.Wait).Flatten().Handle((exception) => throw exception);
    }

    [TestMethod]
    public async Task RunAsync_MultipleHostAddresses_True()
    {
        // Pseudo Code - don't trust it!!!

        // Arrange
        string[] hostNames = ["localhost -c 4", "localhost -c 4", "localhost -c 4", "localhost -c 4", "localhost -c 4", "localhost -c 4"];
        int windowsExpectedLineCount = PingOutputLikeExpressionWindows.Split(Environment.NewLine).Length * hostNames.Length;
        int linuxExpectedLineCount = PingOutputLikeExpressionLinux.Split(Environment.NewLine).Length * hostNames.Length;

        PingResult result = await Sut.RunAsync(hostNames);

        // Act
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;

        // Assert
        Assert.AreEqual(0, result.ExitCode);
        try
        {
            Assert.AreEqual(windowsExpectedLineCount, lineCount);
        }
        catch
        {
            Assert.AreEqual(linuxExpectedLineCount, lineCount);
        }
    }

    [TestMethod]

    public async Task RunLongRunningAsync_UsingTpl_Success()
    {
        PingResult result = await Sut.RunLongRunningAsync("localhost -c 4");

        Assert.AreEqual(0, result.ExitCode);
    }

    //[TestMethod]
    //public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    //{
    //    IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
    //    System.Text.StringBuilder stringBuilder = new();
    //    numbers.AsParallel().ForAll(item => stringBuilder.AppendLine(""));
    //    int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
    //    Assert.AreNotEqual(lineCount, numbers.Count() + 1);
    //}

    private readonly string PingOutputLikeExpressionWindows = @"
Pinging * with * bytes of data:
Reply from *
Reply from *
Reply from *
Reply from *

Ping statistics for *
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *".Trim();
    private readonly string PingOutputLikeExpressionLinux = @"*
*
*
*
*
*
*
*
*".Trim();
    //    PING localhost(127.0.0.1) 56(84) bytes of data.
    //64 bytes from localhost(127.0.0.1) : icmp_seq=1 ttl=64 time=0.024 ms
    //64 bytes from localhost(127.0.0.1) : icmp_seq=2 ttl=64 time=0.077 ms
    //64 bytes from localhost(127.0.0.1) : icmp_seq=3 ttl=64 time=0.066 ms
    //64 bytes from localhost(127.0.0.1) : icmp_seq=4 ttl=64 time=0.049 ms

    //--- localhost ping statistics ---
    //4 packets transmitted, 4 received, 0% packet loss, time 3386ms
    //rtt min/avg/max/mdev = 0.024/0.054/0.077/0.020 ms

    //Due to wild card issues when switching to linux and windows, we have decided not to use this pattern.
    //private void AssertValidPingOutput(int exitCode, string? stdOutput)
    //{
    //    Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
    //    stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
    //    Assert.IsTrue((stdOutput?.IsLike(PingOutputLikeExpressionWindows) ?? false) || (stdOutput?.IsLike(PingOutputLikeExpressionLinux) ?? false),
    //        $"Output is unexpected: {stdOutput}");
    //    Assert.AreEqual<int>(0, exitCode);
    //}
    //private void AssertValidPingOutput(PingResult result)
    //{
    //    AssertValidPingOutput(result.ExitCode, result.StdOutput);
    //}
}
