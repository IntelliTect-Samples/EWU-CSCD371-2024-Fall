using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Logger.Tests;



[TestClass]
public class FileLoggerTests
{
    private string _logFilePath = string.Empty;

    [TestInitialize]
    public void Setup()
    {
        //set up logger file path
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        _logFilePath = Path.Combine(assemblyPath, "file.txt");

        // clear file contents if it already exists 
        if (File.Exists(_logFilePath))
        {
            File.Delete(_logFilePath);
        }
    

    }
   
    [TestMethod]
    public void Log_AppendMessageInFile_Pass()
    {
        //arrange
        var fileLogger = new FileLogger(_logFilePath, "testClass");
        string testMessage = "Test message";

        //act
        fileLogger.Log(LogLevel.Information, testMessage);
        var logMessage = File.ReadAllText(_logFilePath);
        //
        Assert.IsTrue(logMessage.Contains(testMessage));
        Assert.IsTrue(logMessage.Contains("Information"));
        Assert.IsTrue(logMessage.Contains("testClass"));
        
    }
    [TestMethod]
    public void FileLogger_NullFilePath_ThrowExecption() 
    {
        //arrange
        string? fake = null;

        //Act
        //Assert
        Assert.ThrowsException<ArgumentNullException>(() => new FileLogger(fake, "FailTest")); 
    }

}

