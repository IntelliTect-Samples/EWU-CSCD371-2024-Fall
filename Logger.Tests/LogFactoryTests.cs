using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{

    /*
     * This test expects CreateLogger to return null when there isn't a file path configured for LogFactory
     * because I haven't implemented the ConfigureFileLogger method, resulting in the factory being unconfigured.
     */

    [TestMethod]
    public void CreateLogger_NoConfiguration_Null()
    {
        //Arrange
        LogFactory factory = new();
        factory.ConfigureFileLogger(null);

        //Act
        BaseLogger? logger = factory.CreateLogger("TestClass");

        //Assert
        Assert.IsNull(logger);
    }

    [TestMethod]
    public void ConfigureFileLogger_Filepath_Success()
    {
        //Arrange
        LogFactory factory = new();
        string testFilePath = "TestPath";

        //Act
        factory.ConfigureFileLogger(testFilePath);

        //Assert
        Assert.AreEqual(testFilePath, factory.FilePath);

    }

    [TestMethod]
    public void CreateLogger_WithNullFilePath_Null()
    {
        //Arrange
        LogFactory factory = new();
        string testClass = "TestClass";
        factory.ConfigureFileLogger(null);

        //Act
        BaseLogger? logger = factory.CreateLogger(testClass);

        //Assert
        Assert.IsNull(logger);
    }

    [TestMethod]
    public void CreateLogger_WithConfiguration_FileLogger()
    {
        //Arrange
        LogFactory factory = new();
        string testFilePath = "TestPath";
        string testClass = "TestClass";
        factory.ConfigureFileLogger(testFilePath);

        //Act
        FileLogger? logger = factory.CreateLogger(testClass);

        //Assert
        Assert.IsNotNull (logger);
        Assert.IsInstanceOfType(logger, typeof(FileLogger));
        Assert.AreEqual(testClass, logger!.ClassName);
        // Used the ! only because we assert that the logger is not null
    }
}