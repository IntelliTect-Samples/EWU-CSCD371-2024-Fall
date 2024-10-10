using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        BaseLogger logger = null!;

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
        TestLogger logger = new();
        string message = "Message for {0}";
        object arg = level.ToString();

        // Act
        logger.Log(level, message, arg);

        // Assert
        var logged = logger.LoggedMessages.Last();
        Assert.AreEqual(level, logged.LogLevel);
        Assert.AreEqual($"Message for {level}", logged.Message);
    }

    /*
     * Each datarow specifies a method name as a string and a corresponding message.
     * This effectively demonstrates invoing different logging methods based on the input from the DataRow.
     * The switch statement is handling the conversion from string method name to the method call.
     * After I invoke the logging method, the test will check whether the log methods are working as intended from the assertion.
     */

    [TestMethod]
    [DataRow("Error", "Error message")]
    [DataRow("Warning", "Warning message")]
    [DataRow("Information", "Information message")]
    [DataRow("Debug", "Debug message")]
    public void Log_WithVariousMethods_LogsCorrectly(string logMethod, string message)
    {
        // Arrange
        var logger = new TestLogger();

        // Act
        switch (logMethod)
        {
            case "Error":
                BaseLoggerMixins.Error(logger, message);
                break;
            case "Warning":
                BaseLoggerMixins.Warning(logger, message);
                break;
            case "Information":
                BaseLoggerMixins.Information(logger, message);
                break;
            case "Debug":
                BaseLoggerMixins.Debug(logger, message);
                break;
            default:
                throw new InvalidOperationException("Unsupported log method");
        }

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        var loggedMessage = logger.LoggedMessages[0];
        Assert.AreEqual(message, loggedMessage.Message);
        Assert.AreEqual(logMethod, loggedMessage.LogLevel.ToString());
    }


    [TestMethod]
    public void ClassName_ValidClassNameString_UpdatesSuccessfully()
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