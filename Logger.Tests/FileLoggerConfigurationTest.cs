using Xunit;

namespace Logger.Tests;

    public class FileLoggerConfigurationTests
    {
        [Fact]
        public void ConstructorValidArgumentsSuccess()
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
        public void ConstructorNullOrWhitespaceFilePathThrowsArgumentException()
        {
            // Arrange
            string filePath = null!;
            string logSource = "MyApp";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void ConstructorNullOrWhitespaceLogSourceThrowsArgumentException()
        {
            // Arrange
            string filePath = "/path/to/log/file.txt";
            string logSource = null!;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void ConstructorEmptyFilePathThrowsArgumentException()
        {
            // Arrange
            string filePath = "";
            string logSource = "MyApp";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void ConstructorEmptyLogSourceThrowsArgumentException()
        {
            // Arrange
            string filePath = "/path/to/log/file.txt";
            string logSource = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void ConstructorWhitespaceFilePathThrowsArgumentException()
        {
            // Arrange
            string filePath = "   ";
            string logSource = "MyApp";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }

        [Fact]
        public void ConstructorWhitespaceLogSourceThrowsArgumentException()
        {
            // Arrange
            string filePath = "/path/to/log/file.txt";
            string logSource = "   ";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLoggerConfiguration(filePath, logSource));
        }
    }
