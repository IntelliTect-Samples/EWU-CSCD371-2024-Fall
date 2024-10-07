using System;
using System.IO;
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
    public void FileLogger_GivenValidPath_CreatesLogger(string path)
    {
        //Arrange
        // Handled by data rows

        // Act
        var logger = new FileLogger(path) { ClassName = "FileLogger" };

        // Assert
        Assert.IsNotNull(logger, "FileLogger should not be null.");
        Assert.IsNotNull(logger.ClassName);
        Assert.AreEqual(logger.ClassName.ToLower(), "filelogger");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileLogger_GivenNullPath_ThrowsArgumentNullException()
    {
        //Arrange
        string path = null;

        //Act
        var logger = new FileLogger(path) { ClassName = "FileLogger" };
    }


    [TestMethod]
    public void GetCallingClassName_ReturnsExpectedClassName()
    {
        //Arrange
        var logger = new FileLogger("C\\:") {ClassName = "FileLogger"};
        string expectedCallingClassName = MethodBase.GetCurrentMethod().DeclaringType.Name;
        //Act
        string callingClassName = logger.GetCallingClassName();
        
        //Assert
        Assert.AreEqual(expectedCallingClassName, callingClassName);
    }

    [TestMethod]
    [DataRow(LogLevel.Warning, "Test message")]
    public void CreateOutputString_ValidInput_ReturnsExpected(LogLevel LogLevel, string message)
    {
        //Arrange
        string path = Path.GetTempPath();
        var logger = new FileLogger(path) { ClassName = "FileLogger" };
        string expectedCaller = MethodBase.GetCurrentMethod().DeclaringType.Name;
        DateTime dateTime = DateTime.Now;
        string expectedOutput = $"{dateTime} {expectedCaller} {LogLevel}: {message}";
        string actualCaller = logger.GetCallingClassName();
        //Act
        string outputString = logger.CreateOutputString(LogLevel, message, dateTime, actualCaller);

        //Assert
        Assert.AreEqual(expectedOutput, outputString);
    }

    [TestMethod]
    public void Log_ValidInputs_AppendsLog(LogLevel LogLevel, string message)
    {
        //Arrange
        string path = Path.GetTempPath();
        var logger = new FileLogger(path) { ClassName = "FileLogger" };

        //Act
        switch (LogLevel)
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

        //Assert
        //check to see if file exists
        //if it does, read the file and check if the message is there
        //use open file to read the file
        //use stream reader to traverse to one away from the end
        //assert/check if the message is there
    }

}
