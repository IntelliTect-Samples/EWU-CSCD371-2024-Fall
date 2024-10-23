using Xunit;

namespace Logger.Tests;

public class FileLoggerTests : FileLoggerTestsBase
{    
    [Fact]
    public void Constructor_GivenClassAndValidFileName_Success()
    {
        Assert.Equal(nameof(FileLoggerTests), Logger.LogSource);
        Assert.Equal(FilePath, Logger.FilePath);
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Constructor_InvalidFilePath_ThrowsException(string? filePath)
    {
        //Arrange

        //Act

        //Assert
        Assert.ThrowsAny<Exception>( () =>
        new FileLogger(nameof(FileLoggerTests), filePath!) );

    }



    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Constructor_InvalidLogSource_ThrowsException(string? logSource)
    {
        //Arrange

        //Act

        //Assert
        Assert.ThrowsAny<Exception>(() =>
        new FileLogger(logSource!,FilePath));
    }

    [Fact]
    public void Constructor_NullFileLoggerConfiguration_ThrowsNullReferenceException()
    {
        //Arrange

        //Act

        //Assert
        Assert.Throws<NullReferenceException>(() =>
        new FileLogger(null!));
    }

    [Fact]
    
    public void Constructor_ValidFileLoggerConfiguration_Constructs()
    {
        //Arrange
        FileLoggerConfiguration config = new(FilePath, nameof(FileLoggerTests));

        //Act
        FileLogger logger =new(config);

        //Assert
        Assert.NotNull(logger);
        Assert.Equal(FilePath, logger.FilePath);
        Assert.Equal(nameof(FileLoggerTests),logger.LogSource);
    }

    //TODO:  ILogger.CreateLogger test for FileLogger

    //In the[class name] [method name] method, We pass in [input] We expect it to [expected]
    [Fact]
    public void CreateLogger_ValidFileLoggerConfiguration_ReturnsFileLogger()
    {
        //Arrange(input)
        FileLoggerConfiguration config = new(FilePath,nameof(FileLoggerTests));

        //Act(call method)
        FileLogger logger = FileLogger.CreateLogger(config);

        //Assert(Assert for expect)
        Assert.NotNull(logger);
        Assert.Equal(nameof(FileLoggerTests),logger.LogSource);
        Assert.Equal(logger.FilePath, FilePath);
    }

    //In the [classname][methodname] method, given [input], we expect [expection]
    [Fact]
    public void CreateLogger_NullFileLoggerConfiguration_ThrowsNullReferenceException ()
    {
        //Arrange(set up inputs for action)
        //Act(Calls defined method ^^^^^)

        //Assert(checks for expected result)
        Assert.Throws<NullReferenceException>(()=>
        FileLogger.CreateLogger(null!)
        );

    }

    [Fact]
    public async Task Log_Message_FileAppended()
    {
        Logger.Log(LogLevel.Error, "Message1");
        Logger.Log(LogLevel.Error, "Message2");

        string[] lines = await File.ReadAllLinesAsync(FilePath);
        Assert.True(lines is [..] and { Length: 2 });
        foreach (string[] line in lines.Select(line => line.Split(',', 4)))
        {
            if (line is [string dateTime, string source, string levelText, string message])
            {
                Assert.True(DateTime.TryParse(dateTime, out _));
                Assert.Equal(nameof(FileLoggerTests), source);
                Assert.True(Enum.TryParse(typeof(LogLevel), levelText, out object? level) ?
                    level is LogLevel.Error : false,"Level was not parsed successfully.");
            }
        }
    }
}
