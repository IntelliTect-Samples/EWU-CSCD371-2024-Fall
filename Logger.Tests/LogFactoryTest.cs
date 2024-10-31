using Xunit;

namespace Logger.Tests
{
    public class LogFactoryTests
    {
        [Fact]
        public void CreateLogger_WhenFileNameIsNull_ReturnsNull()
        {
            // Arrange
            var logFactory = new LogFactory();
            string className = "TestClass";

            // Act
            var logger = logFactory.CreateLogger(className);

            // Assert
            Assert.Null(logger);
        }

        [Fact]
        public void ConfigureFileLogger_SetsFileNameProperty()
        {
            // Arrange
            var logFactory = new LogFactory();
            string fileName = "test.log";

            // Act
            logFactory.ConfigureFileLogger(fileName);

            // Assert
            Assert.Equal(fileName, logFactory.FileName);
        }
    }
}