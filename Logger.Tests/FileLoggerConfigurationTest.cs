using Xunit;

namespace Logger.Tests
{
    public class FileLoggerConfigurationTests
    {
        [Fact]
        public void Constructor_ValidArguments_Success()
        {
            // Arrange
            string filePath = "/path/to/log/file.txt";
            string logSource = "MyApp";

            // Act
            var configuration = new FileLoggerConfiguration(filePath, logSource);

            // Assert
            Assert.Equal(filePath, configuration.FilePath);
            Assert.Equal(logSource, configuration.LogSource);
        }

        [Fact]
        public void Constructor_NullOrWhitespaceFilePath_ThrowsArgumentException()
        {
            // Arrange
            string filePath = null!;
            string logSource = "MyApp";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void Constructor_NullOrWhitespaceLogSource_ThrowsArgumentException()
        {
            // Arrange
            string filePath = "/path/to/log/file.txt";
            string logSource = null!;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void Constructor_EmptyFilePath_ThrowsArgumentException()
        {
            // Arrange
            string filePath = "";
            string logSource = "MyApp";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void Constructor_EmptyLogSource_ThrowsArgumentException()
        {
            // Arrange
            string filePath = "/path/to/log/file.txt";
            string logSource = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void Constructor_WhitespaceFilePath_ThrowsArgumentException()
        {
            // Arrange
            string filePath = "   ";
            string logSource = "MyApp";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void Constructor_WhitespaceLogSource_ThrowsArgumentException()
        {
            // Arrange
            string filePath = "/path/to/log/file.txt";
            string logSource = "   ";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }
    }
}