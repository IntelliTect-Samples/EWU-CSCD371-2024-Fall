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
        Process process = Process.Start("ping", "-c 4 localhost");
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
        Task<PingResult> task = Sut.RunTaskAsync("localhost");
        task.Wait();

        PingResult result = task.Result;

        // Assert
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsTrue(result.StdOutput?.Contains("localhost") == true || result.StdOutput?.Contains("Reply from") == true);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Act
        Task<PingResult> task = Sut.RunAsync("localhost");
        task.Wait();

        PingResult result = task.Result;

        // Assert
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsTrue(result.StdOutput?.Contains("localhost") == true || result.StdOutput?.Contains("Reply from") == true);
    }

    [TestMethod]
    public async Task RunAsync_UsingTpl_Success()
    {
        // Act
        PingResult result = await Sut.RunAsync("localhost");

        // Assert
        Assert.IsTrue(result.StdOutput?.Contains("localhost") == true || result.StdOutput?.Contains("Reply from") == true);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        // Act
        Task<PingResult> task = Sut.RunAsync("localhost", new CancellationToken(true));
        task.Wait();
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        // Arrange
        var cts = new CancellationTokenSource();
        cts.Cancel();
        Task<PingResult> task = Sut.RunAsync("localhost", cts.Token);

        // Act
        try
        {
            task.Wait();
        }
        catch (AggregateException ex)
        {
            AggregateException flattened = ex.Flatten();
            Exception? taskCanceledException = flattened.InnerExceptions.FirstOrDefault(e => e is TaskCanceledException);

            Assert.IsNotNull(taskCanceledException, "Expected an inner TaskCanceledException");
            throw taskCanceledException!;
        }
    }

    [TestMethod]
    public async Task RunAsync_MultipleHostAddresses_True()
    {
        // Arrange
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length * hostNames.Length;

        // Act
        PingResult result = await Sut.RunAsync(hostNames);
        Console.WriteLine("Final Aggregated Output:\n" + result.StdOutput);

        // Assert
        int? lineCount = result.StdOutput?.Trim().Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsTrue(result.StdOutput?.Contains("localhost") == true || result.StdOutput?.Contains("Reply from") == true);
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
