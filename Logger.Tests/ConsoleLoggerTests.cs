using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace Logger.Tests;

[TestClass]
public class ConsoleLoggerTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ConsoleLogger_GivenNullPath_ThrowsArgumentNullException()
    {
        //Arrange

        //Act
        var logger = new ConsoleLogger() { ClassName = nameof(ConsoleLoggerTests).ToLower() };
    }

    [TestMethod]
    public void GetCallingClassName_ReturnsExpectedClassName()
    {
        //Arrange
        var logger = new ConsoleLogger() { ClassName = nameof(ConsoleLoggerTests).ToLower() };
        string? expectedCallingClassName = MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
        //Act
        string? callingClassName = logger.GetCallingClassName();

        //Assert
        Assert.AreEqual(expectedCallingClassName, callingClassName);
    }

    [TestMethod]
    [DataRow(LogLevel.Warning, "Test message")]
    [DataRow(LogLevel.Error, "Test message")]
    [DataRow(LogLevel.Information, "Test message")]
    [DataRow(LogLevel.Debug, "Test message")]
    public void CreateOutputString_ValidInput_ReturnsExpected(LogLevel LogLevel, string message)
    {
        //Arrange
        string? expectedCaller = MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
        var logger = new ConsoleLogger() { ClassName = expectedCaller };

        DateTime dateTime = DateTime.Now;
        string expectedOutput = $"{dateTime} {expectedCaller} {LogLevel}: {message}";

        //Act
        string outputString = logger.CreateOutputString(LogLevel, message, dateTime, expectedCaller);

        //Assert
        Assert.AreEqual(expectedOutput, outputString);
    }

    [TestMethod]
    [DataRow(LogLevel.Error, "Hello!")]
    [DataRow(LogLevel.Warning, "Hello!")]
    [DataRow(LogLevel.Debug, "Hello!")]
    [DataRow(LogLevel.Information, "Hello!")]
    public void Log_ValidInputs_PrintsToConsole(LogLevel logLevel, string message)
    {
        //Arrange
        string caller = nameof(FileLoggerTests).ToLower();
        var logger = new ConsoleLogger() { ClassName = caller };
        string expectedOutput = DateTime.Now + " " + caller + " " + logLevel + ": " + message;

        StringWriter? consoleOutput;
        using (consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);

            //Act
            switch (logLevel)
            {
                case LogLevel.Error:
                    logger.Error(message);
                    break;
                case LogLevel.Warning:
                    logger.Warning(message);
                    break;
                case LogLevel.Information:
                    logger.Information(message);
                    break;
                case LogLevel.Debug:
                    logger.Debug(message);
                    break;
            }

            Console.Out.Flush();
        }

        //Assert
        string actualOutput = consoleOutput.ToString().Trim();
        Assert.AreEqual(actualOutput, expectedOutput);
    }

}