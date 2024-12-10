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

    //[TestMethod]
    //public void Run_GoogleDotCom_Success()
    //{
    //    int exitCode = Sut.Run("-c 4 google.com").ExitCode;
    //    Assert.AreEqual<int>(0, exitCode);
    //} //github can't test this, since it have no internet access


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput) = Sut.Run("badaddress");
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        StringAssert.Contains( //I don't have a linux machine to test the exact output
            "No output captured for host: badaddress".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(2, exitCode);
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
        // Do NOT use async/await in this test.
        // Test Sut.RunTaskAsync("-c 4 localhost");
        Task<PingResult> result = Sut.RunTaskAsync("-c 4 localhost");
        //result.Wait();

        AssertValidPingOutput(result.Result);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        // Do NOT use async/await in this test.
        PingResult result = Sut.RunAsync("-c 4 localhost").Result;
        // Test Sut.RunAsync("-c 4 localhost");
        AssertValidPingOutput(result);
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        // DO use async/await in this test.
        PingResult result = await Sut.RunAsync("-c 4 localhost");

        // Test Sut.RunAsync("-c 4 localhost");
        AssertValidPingOutput(result);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {

        CancellationTokenSource cts = new();
        var token = cts.Token;
        Task<PingResult> pr = Sut.RunAsync("-c 4 localhost", token);
        cts.Cancel();
        PingResult temp = pr.Result;


    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        try
        {

            CancellationTokenSource cts = new();
            Task<PingResult> pr = Sut.RunAsync("-c 4 localhost", cts.Token);
            cts.Cancel();
            PingResult asdf = pr.Result;
        }
        catch (AggregateException ex)
        {
            foreach (var e in ex.Flatten().InnerExceptions)
            {
                throw e;
            }
        }


    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        string[] hostNames = new string[] { "-c 4 localhost", "-c 4 localhost", "-c 4 localhost", "-c 4 localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.TrimEnd().Split(Environment.NewLine).Length;
        Assert.AreEqual(expectedLineCount, lineCount);
    }

    [TestMethod]
    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        var startInfo = new ProcessStartInfo("ping", "-c 4 localhost");
        int exitCode = await Sut.RunLongRunningAsync(startInfo, null, null, default);
        Assert.AreEqual(0, exitCode);
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {

        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();
        object lockObj = new(); 

        numbers.AsParallel().ForAll(item =>
        {
            lock (lockObj)
            {
                stringBuilder.AppendLine("");
            }
        });
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;
        Assert.AreNotEqual(lineCount, numbers.Count());
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
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
