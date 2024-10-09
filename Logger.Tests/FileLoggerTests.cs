using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace Logger.Tests;
/*
 - Create a `FileLogger` that derives from `BaseLogger`. It should take in a path to a file to write the log message to. When its `Log` method is called, it should **append** messages on their own line in the file. The output should include all of the following:
   - The current date/time ❌✔
   - The name of the class that created the logger ❌✔
   - The log level ❌✔
   - The message ❌✔
   - The format may vary, but an example might look like this "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
 */


[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    [DataRow("")]
    [DataRow("C:\\")]
    [DataRow("C:\\Users\\test\\Documents")]
    public void FileLogger_GivenValidPath_CreatesLogger(string? path)
    {
        //Arrange
        // Handled by data rows

        // Act
        var logger = new FileLogger(path) { ClassName = nameof(FileLoggerTests) };

        // Assert
        Assert.IsNotNull(logger, "FileLogger should not be null.");
        Assert.IsNotNull(logger.ClassName);
        Assert.AreEqual(logger.ClassName, nameof(FileLoggerTests));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileLogger_GivenNullPath_ThrowsArgumentNullException()
    {
        //Arrange
        string? path = null;

        //Act
        var logger = new FileLogger(path) { ClassName = nameof(FileLoggerTests) };
    }


    [TestMethod]
    [DataRow(LogLevel.Warning, "Test message")]
    [DataRow(LogLevel.Error, "Test message")]
    [DataRow(LogLevel.Information, "Test message")]
    [DataRow(LogLevel.Debug, "Test message")]

    public void CreateOutputString_ValidInput_ReturnsExpected(LogLevel LogLevel, string message)
    {
        //Arrange
        string? path = Path.GetTempPath();
        string? expectedCaller = MethodBase.GetCurrentMethod()?.DeclaringType?.Name;
        var logger = new FileLogger(path) { ClassName = expectedCaller };
        
        //we see on this next line that we can grab the current method's calling class name
        
        DateTime dateTime = DateTime.Now;
        string expectedOutput = $"{dateTime} {expectedCaller} {LogLevel}: {message}";
       

        //Act
        //I don't care for having to pass the dateTime and actualCaller in as arguments
        //There are unique reasons why it's easier to pass them in as parameters
        //These reasons aid in testing but limit the method's usability
        string outputString = FileLogger.CreateOutputString(LogLevel, message, dateTime, expectedCaller);

        //Assert
        Assert.AreEqual(expectedOutput, outputString);
    }

    [TestMethod]
    [DataRow(LogLevel.Error, "Hello!", "./")]
    [DataRow(LogLevel.Warning, "Hello!", ".\\")]
    [DataRow(LogLevel.Debug, "Hello!", "./")]
    [DataRow(LogLevel.Information, "Hello!", ".\\")]

    [DataRow(LogLevel.Error, "Hello!", "./")]
    public void Log_ValidInputs_AppendsLog(LogLevel logLevel, string message, string path)
    {
        //Arrange
        //path = Directory.GetCurrentDirectory();
        string caller =nameof(FileLoggerTests);

        var logger = new FileLogger(path) { ClassName = caller };
        string expectedOutput = DateTime.Now + " " + caller + " " + logLevel + ": " + message;

        path = System.IO.Path.Combine(path, logLevel + ".txt");
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

        string result = File.ReadAllText(path);

        // Assert
        Assert.IsTrue(result.Contains(expectedOutput), "The file could not be appended.Expected: "+expectedOutput+Environment.NewLine+"Full result: "+result);
    }
}
