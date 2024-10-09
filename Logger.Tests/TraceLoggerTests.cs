using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class TraceLoggerTests : IDisposable
{
    private sealed class TestTraceListener : TraceListener
    {
        public List<string> Messages { get; } = new List<string>();

        public override void Write(string? message)
        {
            if (message == null)
            {
                Messages.Add("Warning: Attempted to write a null message");
                return;
            }
            Messages.Add(message);
        }

        public override void WriteLine(string? message)
        {
            if (message == null)
            {
                Messages.Add("Warning: Attempted to write a null message");
                return;
            }
            Messages.Add(message);
        }
    }

    private TestTraceListener? Listener { get; set; }

    [TestInitialize]
    public void Setup()
    {
        Listener = new TestTraceListener();
        Trace.Listeners.Add(Listener);
    }

    [TestMethod]
    public void Constructor_SetsClassName_Correctly()
    {
        //Arrange
        var expectedClassName = "TraceLoggerTests";

        //Act
        var logger = new TraceLogger(nameof(TraceLoggerTests));

        //Assert
        Assert.AreEqual(expectedClassName, logger.ClassName);
    }

    [TestMethod]
    [DataRow(LogLevel.Information, "Test message", "Information: Test message")]
    [DataRow(LogLevel.Error, "Error occurred", "Error: Error occurred")]
    [DataRow(LogLevel.Warning, "Warning issued", "Warning: Warning issued")]
    [DataRow(LogLevel.Debug, "Debug info", "Debug: Debug info")]
    public void Log_LogsDifferentMessages_Correctly(LogLevel level, string message, string expectedOutput)
    {
        // Arrange
        var logger = new TraceLogger("TestLogger");

        // Act
        logger.Log(level, message);
        bool isMessageLogged = Listener!.Messages.Any(loggedMessage => loggedMessage.Contains(expectedOutput));

        // Assert
        Assert.IsTrue(isMessageLogged, $"Failed to log '{expectedOutput}' for level {level}");
    }

    [TestMethod]
    public void Dispose_WhenListenerIsNotNull_DisposesListener()
    {
        // Arrange

        // Act
        Dispose();

        // Assert
        Assert.IsNull(Listener);
    }

    [TestMethod]
    public void Write_WhenMessageIsNull_AddsWarningToMessage()
    {
        //Arrange
        string? message = null;

        //Act
        Listener!.Write(message);

        //Assert
        Assert.AreEqual(1, Listener.Messages.Count);
        Assert.AreEqual("Warning: Attempted to write a null message", Listener.Messages[0]);
    }

    [TestMethod]
    public void WriteLine_WhenMessageIsNull_AddsWarningToMessage()
    {
        //Arrange
        string? message = null;

        //Act
        Listener!.WriteLine(message);

        //Assert
        Assert.AreEqual(1, Listener.Messages.Count);
        Assert.AreEqual("Warning: Attempted to write a null message", Listener.Messages[0]);
    }

    [TestMethod]
    public void Cleaup_RemovesListenerFromTrace_Correctly()
    {
        //Arrange
        //Act
        Cleanup();

        //Assert
        Assert.IsFalse(Trace.Listeners.Contains(Listener));
    }

    public void Dispose()
    {
        Listener?.Dispose();
        Listener = null;
        GC.SuppressFinalize(this);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Trace.Listeners.Remove(Listener);
    }
}
