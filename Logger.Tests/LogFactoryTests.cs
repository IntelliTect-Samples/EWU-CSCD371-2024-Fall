using Xunit;

namespace Logger.Tests;

public class LogFactoryTests : FileLoggerTestsBase
{
    [Fact]
    public void ConfigureFileLogger_GivenFilePath_ReturnsFileLoggerWithSetFilePath()
    {
        //Arrange
        LogFactory logFactory = new();

        //Act
        logFactory.ConfigureFileLogger(FilePath);

        //Assert
        Assert.NotNull(Logger);
        Assert.Equal(FilePath, Logger.FilePath);
    }

    [Fact]
    public void FilePath_ValidPath_CreatesFilePath()
    {
        //Arrange
        LogFactory loggerFactory = new();

        //Act
        loggerFactory.FilePath = FilePath;

        //Assert
        Assert.Equal(FilePath, loggerFactory.FilePath);
    }

    [Fact]
    public void CreateLogger_ValidInputs_CreatesLogger()
    {
        //Arrange
        LogFactory loggingFactory = new();
        loggingFactory.ConfigureFileLogger(FilePath);

        //Act
        FileLogger? logger =(FileLogger?) loggingFactory.CreateLogger(nameof(LogFactoryTests));

        //Assert
        Assert.NotNull(logger);
        Assert.Equal(FilePath,logger.FilePath);
        Assert.Equal(nameof(LogFactoryTests),logger.LogSource);
    }

    [Fact]
    public void CreateLogger_NullFilePath_ReturnsNull()
    {
        //Arrange
        LogFactory factory = new();

        //Act
        FileLogger? logger =(FileLogger?)factory.CreateLogger(nameof(LogFactoryTests));

        //Assert
        Assert.Null(logger);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\n")]

    public void CreateLogger_NullOrEmptyLogSource_ThrowsArgumentException(string? logSource)
    {
        //Arrange
        LogFactory factory = new();
        factory.ConfigureFileLogger(FilePath);

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() =>
           factory.CreateLogger(logSource!));
    } 
}