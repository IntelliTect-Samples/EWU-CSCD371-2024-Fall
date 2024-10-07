using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    [DataRow(null)]
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


}
