using System;
using System.Diagnostics;
using System.Threading;
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
        Process process = Process.Start("ping", "localhost -c 4");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("8.8.8.8 -c 4").ExitCode;
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
        Assert.AreEqual<int>(2, exitCode);
    }

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        PingResult result = Sut.Run("-c 4 localhost");
        Assert.AreEqual(0, result.ExitCode);
        AssertValidPingOutput(result);
    }

    [TestMethod]
    [DataRow("amazon.com -c 4")]
    [DataRow("8.8.8.8 -c 4")]
    [DataRow("www.walmart.com -c 4")]
    public void RunTaskAsync_Success(string address)
    {
        // Do NOT use async/await in this test.
        // Test Sut.RunTaskAsync("localhost");

        //Act
        Task<PingResult> result = Sut.RunTaskAsync(address);
        result.Wait();

        //Assert
        Assert.AreEqual(1, result.Result.ExitCode);
        Assert.IsNotNull(result.Result);

    }

    [TestMethod]
    [DataRow("amazon.com -c 4")]
    [DataRow("8.8.8.8 -c 4")]
    [DataRow("www.walmart.com -c 4")]
    public void RunAsync_UsingTaskReturn_Success(string address)
    {
        // Do NOT use async/await in this test.
        // Test Sut.RunAsync("localhost");

        //Act
        Task<PingResult> pingResult = Sut.RunAsync(address);
        pingResult.Wait();

        //Assert
        Assert.AreEqual(1, pingResult.Result.ExitCode);
    }

    [TestMethod]

    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        PingResult result = await Sut.RunAsync("-c 4 localhost");

        // Test Sut.RunAsync("localhost");
        AssertValidPingOutput(result);
    }



    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        //Arrange 
        CancellationToken cancellationToken = new(true);

        //Act
        Task<PingResult> results = Sut.RunAsync("localhost -c 4", cancellationToken);
        results.Wait();

        //Assert
        Assert.AreEqual(0, results.Result.ExitCode);

    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Use exception.Flatten()
        //Arrange
        CancellationTokenSource cancellationSourse = new();
        cancellationSourse.Cancel();
        try
        {

            //Act 
            Task<PingResult> result = Sut.RunAsync("localhost -c 4", cancellationSourse.Token);
            result.Wait();
        }
        catch (AggregateException ex)
        {
            var flat = ex.Flatten();
            if (flat.InnerException is TaskCanceledException)
            {
                throw flat.InnerException;
            }
            else { throw; }
        }
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        string[] hostNames = new string[] { "localhost -c 4", "localhost -c 4", "localhost -c 4" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount + 1, lineCount);
    }

    [TestMethod]
#pragma warning disable CS1998 // Remove this
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        //PingResult result = await Sut.RunLongRunningAsync("localhost -c 4");

        //Assert.AreEqual(0, result.ExitCode);
        //AssertValidPingOutput(result);
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
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression) ?? false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
