using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LoggerFactoryTests
{
    [TestMethod]
    [DataRow("")]
    [DataRow("./")]
    [DataRow("/C:/Users/test/Documents")]
    [DataRow(null)]

    public void ConfigureFileLogger_GivenString_StoresValue(string? path)
    {
        //arrange
        FileLoggerFactory factory = new FileLoggerFactory();
        //act
        factory.ConfigureFileLogger(path);
        //assert
        Assert.AreEqual(factory.FilePath, path);
    }

    [TestMethod]
    public void CreateLogger_FileLoggerClass_ReturnsLogger()
    {

        //Arrange
        FileLoggerFactory factory = new();
        factory.ConfigureFileLogger(Environment.ProcessPath) ;
        //Act

        FileLogger? logger = factory.CreateLogger();
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(logger),"logger");
    }

    [TestMethod]
    public void CreateLogger_TestLoggerClass_ReturnsNull()
    {

        //Arrange
        TestLoggerFactory factory = new();
        //act
        TestLogger? logger = factory.CreateLogger();
        //Assert
        Assert.IsNull(logger);
        Assert.AreEqual(nameof(logger).ToLower(), "testlogger");
    }
}
