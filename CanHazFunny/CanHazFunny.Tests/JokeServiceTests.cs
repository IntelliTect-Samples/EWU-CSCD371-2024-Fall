using Xunit;
using Moq;
using System;

namespace CanHazFunny.Tests
{
    public class JokeServiceTests
    {
        [Fact]
        public void IJokeService_GetJoke_ReturnsExpectedJoke()
        {
            // Arrange
            var jokeServiceMock = new Mock<IJokeService>();
            string expectedJoke = "What do you call fake spaghetti? An impasta!";
            jokeServiceMock.Setup(service => service.GetJoke()).Returns(expectedJoke);

            // Act
            string actualJoke = jokeServiceMock.Object.GetJoke();

            // Assert
            Assert.Equal(expectedJoke, actualJoke);
        }

        [Fact]
        public void GetJoke_Called_ReturnsNonEmptyString()
        {
            // Arrange
            var service = new JokeService();

            // Act
            var result = service.GetJoke();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.IsType<string>(result);
        }
    }
}
