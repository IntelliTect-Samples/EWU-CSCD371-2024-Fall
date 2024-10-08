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
    [DataRow("TestLogger")]
    [DataRow("FileLogger")]
    public void CreateLogger_ValidClassName_ReturnsLogger(string className)
    {

        //Arrange
        LogFactory factory = new();
        if (className.ToLower().Equals("filelogger")) factory.ConfigureFileLogger(Environment.ProcessPath) ;
        //act

        BaseLogger? logger = factory.CreateLogger(className);
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(logger),"logger");
        Assert.AreEqual(className.ToLower(), logger?.ClassName?.ToLower());
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
