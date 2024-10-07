using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{
    [TestMethod]
    [DataRow(LogLevel.Error)]
    [DataRow(LogLevel.Warning)]
    [DataRow(LogLevel.Information)]
    [DataRow(LogLevel.Debug)]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Log_WithNullLogger_ThrowsException(LogLevel level)
    {
        // Arrange
        BaseLogger logger = null;

        // Act
        BaseLoggerMixins.Log(logger, level, "This should throw an exception.");

        // Assert
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