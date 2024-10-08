using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_Creation_Test_Successful()
    {
        //Arrange
        var logFactory = new LogFactory();
        logFactory.ConfigureFileLogger();
        //Act
        var testLogger = logFactory.CreateLogger("Test");
        //Assert
        Assert.IsNotNull(testLogger);
    }
    [TestMethod]
    public void ConfigureFileLogger_FilePathCorrect()
    {
        //Arrange
        var logFactory = new LogFactory();
        var logger = logFactory.FilePath;
        string expectedFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //Act
        logFactory.ConfigureFileLogger(expectedFilePath);
        //Assert
        Assert.AreEqual(expectedFilePath, logger.FilePath);
        
    }

}
