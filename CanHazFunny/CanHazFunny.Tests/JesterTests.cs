using System;
using Xunit;
using Interfaces;
using Moq;

namespace CanHazFunny.Tests;
    public class JesterTests
    {
        [Fact]
        public void JokeService_CallGetJoke_ReturnsJokeNotNullOrEmpty()
        {
            // Arrange
            JokeService jokeService = new();

            // Act
            string joke = jokeService.GetJoke();
            bool isJoke = !string.IsNullOrEmpty(joke);

            // Assert
            Assert.True(isJoke, "Joke is there");
        }

        [Fact]
        public void JokeServiceInterface_IJokeServic_ReturnsTrue()
        {
            // Arrange
            var jokeService = typeof(JokeService);

            // Act
            var appliedInterface = jokeService.GetInterfaces();
            string interfaceName = appliedInterface[0].Name;

            // Assert
            Assert.Equal("IJokeService", interfaceName);
        }

        [Fact]
        public void JesterClass_TellJoke_ReturnsJoke()
        {
            // Arrange
            JokeService jokeServ = new();
            IJokeService jokeService = jokeServ;
            ConsoleJokeOutput jokeOutput = new();
            IJokeOutput jokeOutputLog = jokeOutput;

            Jester jester = new(jokeService, jokeOutputLog);

            // Act
            string joke = jester.TellJoke();
            bool isJoke = !string.IsNullOrEmpty(joke);

            // Assert
            Assert.True(isJoke, "This returns a string");
        }

        [Fact]
        public void JesterTellJoke_NoChuckNorris_ReturnsTrue()
        {
            // Arrange
            JokeService jokeServ = new();
            IJokeService jokeService = jokeServ;
            ConsoleJokeOutput jokeOutput = new();
            IJokeOutput jokeOutputLog = jokeOutput;

            Jester jester = new(jokeService, jokeOutputLog);

            // Act
            string joke = jester.TellJoke();
            bool noChuckNorris = !(joke.Contains("chuck norris", StringComparison.InvariantCultureIgnoreCase));

            // Assert
            Assert.True(noChuckNorris, "Joke contains Chuck Norris");
        }

        [Fact]
        public void JesterConstructor_NullJokeService_ThrowsArgumentNullException()
        {
            // Arrange
            IJokeOutput jokeOutput = new ConsoleJokeOutput();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Jester(null!, jokeOutput));
        }

        [Fact]
        public void JesterConstructor_NullJokeOutput_ThrowsArgumentNullException()
        {
            // Arrange
            IJokeService jokeService = new JokeService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Jester(jokeService, null!));
        }

        [Fact]
        public void TellJoke_JokeServiceReturnsNull_ThrowsException()
        {
            // Arrange
            var mockJokeService = new Mock<IJokeService>();
            mockJokeService.Setup(js => js.GetJoke()).Returns((string)null!);
            var mockJokeOutput = new Mock<IJokeOutput>();
            var jester = new Jester(mockJokeService.Object, mockJokeOutput.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => jester.TellJoke());
        }

        // New tests with mock dependencies

        [Fact]
        public void TellJoke_WhenChuckNorrisJoke_ShouldRetryUntilNoChuckNorris()
        {
            // Arrange
            var mockJokeService = new Mock<IJokeService>();
            var mockJokeOutput = new Mock<IJokeOutput>();

            // Simulate the joke service returning a Chuck Norris joke first, then a valid joke
            mockJokeService.SetupSequence(service => service.GetJoke())
                .Returns("Chuck Norris joke")  // First call returns a Chuck Norris joke
                .Returns("This is a valid joke");  // Second call returns a valid joke

            Jester jester = new (mockJokeService.Object, mockJokeOutput.Object);

            // Act
            string joke = jester.TellJoke();

            // Assert
            Assert.Equal("This is a valid joke", joke);
            mockJokeService.Verify(service => service.GetJoke(), Times.Exactly(2));  // Ensure GetJoke was called twice
            mockJokeOutput.Verify(output => output.OutputJoke("This is a valid joke"), Times.Once);  // Ensure OutputJoke was called with the correct joke
        }

        [Fact]
        public void TellJoke_WhenServiceReturnsNull_ShouldThrowException()
        {
            // Arrange
            var mockJokeService = new Mock<IJokeService>();
            var mockJokeOutput = new Mock<IJokeOutput>();

            // Simulate the joke service returning null
            mockJokeService.Setup(service => service.GetJoke()).Returns((string)null!);

            Jester jester = new (mockJokeService.Object, mockJokeOutput.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => jester.TellJoke());
        }

        [Fact]
        public void TellJoke_ShouldCallOutputJokeWithValidJoke()
        {
            // Arrange
            var mockJokeService = new Mock<IJokeService>();
            var mockJokeOutput = new Mock<IJokeOutput>();

            // Simulate the joke service returning a valid joke
            mockJokeService.Setup(service => service.GetJoke()).Returns("This is a test joke");

            Jester jester = new (mockJokeService.Object, mockJokeOutput.Object);

            // Act
            jester.TellJoke();

            // Assert
            mockJokeOutput.Verify(output => output.OutputJoke("This is a test joke"), Times.Once);  // Ensure OutputJoke was called with the correct joke
        }
    }


