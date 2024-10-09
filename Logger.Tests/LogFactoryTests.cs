using System;

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
    public void ConfigureFileLogger_NullFilePath_ThrowsException()
    {
        //Arrange
        string? nullFilePath = null;

        //Act
        LogFactory factory = new();

        //Assert
        Assert.ThrowsException<ArgumentException>(() => factory.ConfigureFileLogger(nullFilePath!));
    }

    [TestMethod]
    public void ConfigureFileLogger_EmptyFilePath_ThrowsException()
    {
        //Arrange
        string emptyFilePath = string.Empty;

        //Act
        LogFactory factory = new();

        //Assert
        Assert.ThrowsException<ArgumentException>(() => factory.ConfigureFileLogger(emptyFilePath));
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
    public void CreateLogger_WithNoConfiguration_Null()
    {
        //Arrange
        string testClassName = "TestClass";
        LogFactory factory = new();

        //Act
        FileLogger? logger = factory.CreateLogger(testClassName);

        //Assert
        Assert.IsNull(logger);
    }

    [TestMethod]
    public void CreateLogger_WithConfiguration_Success()
    {
        //Arrange
        LogFactory factory = new();
        string testFilePath = "TestPath";
        string testClass = "LogFactoryTests";
        factory.ConfigureFileLogger(testFilePath);

        //Act
        BaseLogger? logger = factory.CreateLogger(nameof(LogFactoryTests));

        //Assert
        Assert.IsNotNull (logger);
        Assert.IsInstanceOfType(logger, typeof(BaseLogger));
        Assert.AreEqual(testClass, logger!.ClassName);
        // Used the ! only because we assert that the logger is not null
    }
}