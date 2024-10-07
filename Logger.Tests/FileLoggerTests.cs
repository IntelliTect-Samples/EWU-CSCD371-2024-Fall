using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void FileLogger_TestClassName_Success()
    {
        //Arrange
        string className = "TestClass";
        string filePath = "TestPath";

        //Act
        FileLogger logger = new(filePath);
        logger.ClassName = className;

        //Assert
        Assert.AreEqual(className, logger.ClassName);
    }

    [TestMethod]
    public void FileLogger_Constructor_Success()
    {
        //Arrange
        string filePath = "TestPath";

        //Act
        FileLogger logger = new(filePath);

        //Assert
        Assert.IsNotNull(logger);
    }

    [TestMethod]
    public void FileLogger_Log_Success()
    {
        //Arrange
        string filePath = "testLogFile.log";
        string expectedLogEntry = "10/7/2019 12:38:59 AM TestLogger Error: Test message";
        string message = "Test message";
        FileLogger logger = new(filePath);
        logger.ClassName = "TestLogger";
        LogLevel logLevel = LogLevel.Error;

        //Act
        logger.Log(logLevel, message);

        //Assert
        string logContents = File.ReadAllText(filePath);
        Assert.IsTrue(logContents.Contains(expectedLogEntry));

    }
}
