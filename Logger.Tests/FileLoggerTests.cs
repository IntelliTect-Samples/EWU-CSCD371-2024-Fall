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
    public void Constructor_TestClassName_Success()
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
    public void Constructor_IsNotNull_Success()
    {
        //Arrange

        //Act
        FileLogger logger = new(FilePath);

        //Assert
        Assert.IsNotNull(logger);
    }

    [TestMethod]
    public void Constructor_PassNullFilePath_ThrowsException()
    {
        //Arrange
        string? filePath = null;

        //Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => new FileLogger(filePath!));
    }

    [TestMethod]
    [DataRow("TestLogger", LogLevel.Error, "Test message")]
    [DataRow("TestLogger", LogLevel.Warning, "Another test message")]
    [DataRow("ProductionLogger", LogLevel.Information, "Information message")]
    [DataRow("DebugLogger", LogLevel.Debug, "Debugging message")]
    public void Log_LogLevelAndMessages_ProducesExpectedOutput(string className, LogLevel logLevel, string message)
    {
        // Arrange
        FileLogger logger = new(FilePath) { ClassName = className };

        //Act
        logger.Log(logLevel, message);

        //Assert
        string logContents = File.ReadAllText(FilePath);
        string expectedLogEntry = $"{DateTime.Now} {className} {logLevel}: {message}{Environment.NewLine}";
        Assert.AreEqual(expectedLogEntry, logContents);
    }

    [TestCleanup]
    public void Cleanup()
    {
        // Cleans up the file after tests
        if (File.Exists(FilePath))
            File.Delete(FilePath);
    }
}
