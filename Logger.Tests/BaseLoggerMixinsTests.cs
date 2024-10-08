﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Error_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act 
        // added ! to suppress null warning since they should be null
        BaseLoggerMixins.Error(null!, "");
        BaseLoggerMixins.Warning(null!, "");
        BaseLoggerMixins.Information(null!, ""); 
        BaseLoggerMixins.Debug(null!, "");

        // Assert
    }

    [TestMethod]
    public void Error_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Error("Message {0}", 42);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    public void Warning_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Warning("Message {0}", 42);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    public void Information_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Information("Message {0}", 42);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    public void Debug_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Debug("Message {0}", 42);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

}

public class TestLogger : BaseLogger
{
    public override string ClassName { get; }
    public TestLogger(string className)
    {
        ClassName = className;
    }
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
    }
}
