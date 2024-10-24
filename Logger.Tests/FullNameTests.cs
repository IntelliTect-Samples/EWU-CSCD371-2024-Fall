using Xunit;

namespace Logger.Tests;

    public class FullNameTests
    {
        [Fact]
        public void ToString_ShouldReturnFullNameWithoutMiddleName_WhenMiddleNameIsNull()
        {
            // Arrange
            var fullName = new FullName("John", null, "Doe");

            // Act
            var result = fullName.ToString();

            // Assert
            Assert.Equal("John Doe", result);
        }

        [Fact]
        public void ToString_ShouldReturnFullNameWithMiddleName_WhenMiddleNameIsNotNull()
        {
            // Arrange
            var fullName = new FullName("John", "Michael", "Doe");

            // Act
            var result = fullName.ToString();

            // Assert
            Assert.Equal("John Michael Doe", result);
        }
    }
