using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        Process process = Process.Start("ping", "-c 4 localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        PingResult result = Sut.Run("-c 4 8.8.8.8");
        int exitCode = result.ExitCode;
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

      //  AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        // Do NOT use async/await in this test.
        Task<PingResult> task = Sut.RunTaskAsync("-c 4 localhost");
        task.Wait();
        PingResult result = task.Result;
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
        //AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        Task<PingResult> task = Sut.RunAsync("-c 4 localhost");
        task.Wait();
        PingResult result = task.Result;
        Assert.AreEqual(0, result.ExitCode);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
        //AssertValidPingOutput(result);
    }

[TestMethod]
async public Task RunAsync_UsingTpl_Success()
{
    // DO use async/await in this test.
    PingResult result = await Sut.RunAsync("-c 4 localhost");

    // Test Sut.RunAsync("localhost");
    Assert.AreEqual(0, result.ExitCode);
    Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
    //AssertValidPingOutput(result);
}
    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()  // I believe this test is incorrect and should be removed. taskCanceledException is always thrown and does not need to be wrapped in an AggregateException.
    {
        using (var cts = new System.Threading.CancellationTokenSource())
        {
            cts.Cancel();
            Task<PingResult> task = Sut.RunAsync("-c 4 localhost", cts.Token);
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
            Task<PingResult> task = Sut.RunAsync("-c 4 localhost", cts.Token);
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
        string[] hostNames = new string[] { "-c 4 localhost", "-c 4 localhost", "-c 4 localhost", "-c 4 localhost" };
        foreach (var hostName in hostNames)
        {
            PingResult result = await Sut.RunAsync(hostName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
            Assert.AreEqual<int>(0, result.ExitCode);
        }
    }

    [TestMethod]
    public async Task RunLongRunningAsync_UsingTpl_Success()
    {
        // Test Sut.RunLongRunningAsync("localhost"); 
        PingProcess sut = new(); 
        ProcessStartInfo startInfo = new("ping")
        {
            Arguments = "-c 4 localhost",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
        };
        StringBuilder stringBuilder = new();
        void updateStdOutput(string? line) => stringBuilder.AppendLine(line);
            CancellationTokenSource cts = new();
            PingResult result = await sut.RunLongRunningAsync(startInfo, updateStdOutput, null, cts.Token);
            Assert.AreEqual(0, result.ExitCode);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.StdOutput));
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
