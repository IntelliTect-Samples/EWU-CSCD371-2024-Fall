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

    public void ConfigureFileLogger_GivenString_StoresValue(string path)
    {
        //arrange
        LogFactory factory = new();
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
       //act
        BaseLogger logger = factory.CreateLogger(className);
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(logger),"logger");
        Assert.AreEqual(className.ToLower(), logger.ClassName.ToLower());
    }

    [TestMethod]
    [DataRow("TestLoggerton")]
    [DataRow(1)]
    [DataRow("")]
    [ExpectedException(typeof(ArgumentException))]
    public void CreateLogger_InvalidClassName_ThrowsError(string? className)
    {

        //Arrange
        LogFactory factory = new();
        //act
        BaseLogger logger = factory.CreateLogger(className);
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(logger), "logger");
    }
}
