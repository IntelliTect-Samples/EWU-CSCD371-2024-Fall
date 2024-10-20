using Xunit;

namespace Logger.Tests;

public class FileLoggerConfigurationTests
{
    [Fact]
    public void Constructor_ValidFilePathAndLogSource_Constructs()
    {
        //Arrange
        string filePath = Path.GetTempFileName();

        //Act
        FileLoggerConfiguration configuration = new(filePath, nameof(FileLoggerConfigurationTests));

        //Assert
        Assert.NotNull(configuration);
        Assert.Equal(nameof(FileLoggerConfigurationTests), configuration.LogSource);
        Assert.Equal(configuration.FilePath, filePath);
    }

    [Theory]
    [InlineData(null, nameof(FileLoggerConfigurationTests))]
    [InlineData("", nameof(FileLoggerConfigurationTests))]
    [InlineData("random file path", "")]
    [InlineData("random file path", null)]
    public void Constructor_NullOrEmptyFilePathOrLogSource_ThrowsArgumentException(string? filePath, string? logSource)
    {
        Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath!, logSource!));
    }
}
