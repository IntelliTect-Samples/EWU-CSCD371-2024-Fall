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
        
        [Fact]
        public void FullName_Equality_AssertsTrue()
        {
            // Arrange
            FullName fullName1 = new FullName("John", string.Empty, "Whick");
            FullName fullName2 = fullName1 with { };
            

            // Act
            bool result = fullName1.Equals(fullName2);

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void FullName_ReferenceEquality_AssertsFalse()
        {
            // Arrange
            FullName fullName1 = new FullName("John", string.Empty, "Whick");

            // Act
            bool result = ReferenceEquals(fullName1, fullName1 with { });

            // Assert
            Assert.False(result);
        }
    }
