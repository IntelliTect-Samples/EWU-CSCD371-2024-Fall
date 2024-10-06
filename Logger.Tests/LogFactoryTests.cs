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
    public void CreateLogger_ValidClassName_ReturnsLogger(string className)
    {

        //Arrange
        LogFactory factory = new();
       //act
        BaseLogger logger = factory.CreateLogger(className);
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(logger),"logger");
    }
}
