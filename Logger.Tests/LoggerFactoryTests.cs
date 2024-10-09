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
        FileLoggerFactory factory = new();
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

        FileLogger? logger = factory.CreateLogger(nameof(LoggerFactoryTests));
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(LoggerFactoryTests), logger!.ClassName);
    }

    [TestMethod]
    public void CreateLogger_ConsoleLoggerClass_ReturnsLogger()
    {
        //Arrange
        ConsoleLoggerFactory factory = new();
        //Act
        ConsoleLogger? logger = factory.CreateLogger(nameof(LoggerFactoryTests));
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(LoggerFactoryTests), logger!.ClassName);
    }

    [TestMethod]
    public void CreateLogger_TestLoggerClass_ReturnsLogger()
    {
        //Arrange
        TestLoggerFactory factory = new();
        //Act
        TestLogger? logger = factory.CreateLogger(nameof(LoggerFactoryTests));
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(LoggerFactoryTests), logger!.ClassName);
    }


}