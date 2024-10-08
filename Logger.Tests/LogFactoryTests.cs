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

    [DataRow("FileLogger")]
    [DataRow("TestLoggerton")]
    [DataRow("")]
    [DataRow(null)]
    public void CreateLogger_InvalidClassName_ReturnsNull(string className)
    {

        //Arrange
        LogFactory factory = new();
        //act
        BaseLogger? logger = factory.CreateLogger(className);
        //Assert
        Assert.IsNull(logger);
    }
}
