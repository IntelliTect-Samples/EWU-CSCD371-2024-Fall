using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        BaseLoggerMixins.Error(null, "");

        // Assert
        //Assertion done with [ExpectedException] above
    }

    [TestMethod]

    [DataRow("Message {0}", "Message 2", new object[] { 2 })]
        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Error(message,insertionValues);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(result, logger.LoggedMessages[0].Message);
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
