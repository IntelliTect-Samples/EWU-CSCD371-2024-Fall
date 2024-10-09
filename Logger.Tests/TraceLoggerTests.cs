using System;
using System.Collections.Generic;
using System.Diagnostics;

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

    private TestTraceListener? _listener;

    [TestInitialize]
    public void Setup()
    {
        _listener = new TestTraceListener();
        Trace.Listeners.Add(_listener);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Trace.Listeners.Remove(_listener);
    }

    public void Dispose()
    {
        _listener?.Dispose();
        _listener = null;
        GC.SuppressFinalize(this);
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
}
