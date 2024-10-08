﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{
    [TestMethod]
    public void Error_WithNullLogger_ThrowsException()
    {
        BaseLogger? logger = null;
       
        string message = "Test error message";

        Assert.ThrowsException<NullReferenceException>(() => logger!.Error(message));

        
    }

    [TestMethod]
    public void Error_WithData_LogsMessage()
    {
        var logger = new TestLogger();

        logger.Error("Message {0}", 42);

        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }
}

public class TestLogger : BaseLogger
{
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
    }
}
