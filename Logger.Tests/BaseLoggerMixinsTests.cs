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
    //Format 
    [DataRow("Message {0}", "Message 2", new object[] { 2 })]
    [DataRow("Message {0}", "Message 2", new object[] { "2" })]
    [DataRow("Message {0}", "Message hello.", new object[] { "hello." })]
    [DataRow("Message {0}{0}", "Message repeatrepeat", new object[] { "repeat" })]
    [DataRow("Message {0}{1}", "Message hello.2", new object[] { "hello.", 2 })]
    [DataRow("Message {1}{0}", "Message hello.2", new object[] { 2, "hello." })]
    [DataRow("Message {0}{1}", "Message hello.2", new object[] { "hello.", 2," third" })]
    [DataRow("Message {2}{1}{0}", "Message third2hello.", new object[] { "hello.", 2, "third" })]
    //Empty stuff
    [DataRow("Empty Message: {0}", "Empty Message: ", new object[] { "" })]
    [DataRow("", "", new object[] { "test" })]
    //null tests
    [DataRow("Empty Message: {0}", "Empty Message: ", new object[] { null })]
    [DataRow(null, "Null message passed in", new object[] { "String here"})]
    [DataRow("", "", null)]

    public void Error_WithValidData_LogsMessage(string message, string result, object[] insertionValues)
    {

        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Error(message, insertionValues);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(result, logger.LoggedMessages[0].Message);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Warning_WithNullLogger_ThrowsException()
    {
        // Arrange

        // Act
        BaseLoggerMixins.Warning(null, "");

        // Assert
        //Assertion done with [ExpectedException] above
    }

    [TestMethod]
    //Format 
    [DataRow("Message {0}", "Message 2", new object[] { 2 })]
    [DataRow("Message {0}", "Message 2", new object[] { "2" })]
    [DataRow("Message {0}", "Message hello.", new object[] { "hello." })]
    [DataRow("Message {0}{0}", "Message repeatrepeat", new object[] { "repeat" })]
    [DataRow("Message {0}{1}", "Message hello.2", new object[] { "hello.", 2 })]
    [DataRow("Message {1}{0}", "Message hello.2", new object[] { 2, "hello." })]
    [DataRow("Message {0}{1}", "Message hello.2", new object[] { "hello.", 2, " third" })]
    [DataRow("Message {2}{1}{0}", "Message third2hello.", new object[] { "hello.", 2, "third" })]
    //Empty stuff
    [DataRow("Empty Message: {0}", "Empty Message: ", new object[] { "" })]
    [DataRow("", "", new object[] { "test" })]
    //null tests
    [DataRow("Empty Message: {0}", "Empty Message: ", new object[] { null })]
    [DataRow(null, "Null message passed in", new object[] { "String here" })]
    [DataRow("", "", null)]

    public void Warning_WithValidData_LogsMessage(string message, string result, object[] insertionValues)
    {

        // Arrange
        var logger = new TestLogger();

        // Act
        logger.Warning(message, insertionValues);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual(result, logger.LoggedMessages[0].Message);
    }


    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}