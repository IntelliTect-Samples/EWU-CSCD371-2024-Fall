using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    private string FilePath {  get; } = "testLogFile.log";

    [TestInitialize]
    public void Setup()
    {
        // Ensures the file is clean before each test
        if (File.Exists(FilePath))
            File.Delete(FilePath);
    }

    [TestMethod]
    public void FileLogger_TestClassName_Success()
    {
        //Arrange
        string className = "TestClass";

        //Act
        FileLogger logger = new(FilePath);
        logger.ClassName = className;

        //Assert
        Assert.AreEqual(className, logger.ClassName);
    }

    [TestMethod]
    public void FileLogger_Constructor_Success()
    {
        //Arrange

        //Act
        FileLogger logger = new(FilePath);

        //Assert
        Assert.IsNotNull(logger);
    }

    [TestMethod]
    public void FileLogger_PassNullFilePath_ThrowsException()
    {
        //Arrange
        string? filePath = null;

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => new FileLogger(filePath!));
    }

    [TestMethod]
    public void FileLogger_Log_Success()
    {
        //Arrange
        string message = "Test message";
        FileLogger logger = new(FilePath);
        string className = logger.ClassName = "TestLogger";
        LogLevel logLevel = LogLevel.Error;

        //Act
        logger.Log(logLevel, message);

        //Assert
        string logContents = File.ReadAllText(FilePath);
        string expectedLogEntry = $"{className} {logLevel}: {message}";
        Assert.IsTrue(logContents.Contains(expectedLogEntry));
    }

    [TestCleanup]
    public void Cleanup()
    {
        // Cleans up the file after tests
        if (File.Exists(FilePath))
            File.Delete(FilePath);
    }
}
