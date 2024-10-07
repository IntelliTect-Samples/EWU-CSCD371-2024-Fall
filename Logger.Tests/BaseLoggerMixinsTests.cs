using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
        BaseLoggerMixins.Error(null, "This will throw an exception.");

        // Assert
    }

    [TestMethod]
    public void Error_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Error("Message {0}", 42);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Warning_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act
        BaseLoggerMixins.Warning(null, "This should throw an exception.");

        // Assert
    }

    [TestMethod]
    public void Warning_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Warning("Warning about {0}", "condition");

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Warning about condition", logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Information_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act
        BaseLoggerMixins.Information(null, "This should throw an exception.");

        // Assert
    }

    [TestMethod]
    public void Information_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Information("Warning about {0}", "condition");

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Warning about condition", logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Debug_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act
        BaseLoggerMixins.Debug(null, "This should throw an exception.");

        // Assert
    }

    [TestMethod]
    public void Debug_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Debug("Warning about {0}", "condition");

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Warning about condition", logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [DataRow(LogLevel.Error)]
    [DataRow(LogLevel.Warning)]
    [DataRow(LogLevel.Information)]
    [DataRow(LogLevel.Debug)]
    public void Log_LogsCorrectly_WithDifferentLevels(LogLevel level)
    {
        // Arrange
        TestLogger logger = new ();
        string message = "Message for {0}";
        object arg = level.ToString();

        // Act
        logger.Log(level, message, arg);

        // Assert
        var logged = logger.LoggedMessages.Last();
        Assert.AreEqual(level, logged.LogLevel);
        Assert.AreEqual($"Message for {level}", logged.Message);
    }

    [TestMethod]
    public void ClassName_TestClass_Success()
    {
        //Arrange
        string className = "TestClass";

        //Act
        TestLogger logger = new();
        logger.ClassName = className;

        //Assert
        Assert.AreEqual(className, logger.ClassName);
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