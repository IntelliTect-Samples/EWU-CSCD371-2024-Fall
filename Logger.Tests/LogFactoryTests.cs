using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    [DataRow("")]
    [DataRow("./")]
    [DataRow("/C:/Users/test/Documents")]
    [DataRow(null)]

    public void ConfigureFileLogger_GivenString_StoresValue(string? path)
    {
        //arrange
        FileLogFactory factory = new FileLogFactory();
        //act
        factory.ConfigureFileLogger(path);
        //assert
        Assert.AreEqual(factory.FilePath, path);
    }

    [TestMethod]
    public void CreateLogger_FileLoggerClass_ReturnsLogger()
    {

        //Arrange
        FileLogFactory factory = new();
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
        TestLogFactory factory = new();
        //act
        TestLogger? logger = factory.CreateLogger();
        //Assert
        Assert.IsNull(logger);
        Assert.AreEqual(nameof(logger).ToLower(), "testlogger");
    }
}
