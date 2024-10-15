using Interfaces;
using Moq;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeOutputTest
{
    [Fact]
    public void JesterTellJokeWritesJokeToOutput()
    {
        // Arrange
        var jokeServiceMock = new Mock<IJokeService>();
        jokeServiceMock.Setup(js => js.GetJoke()).Returns("This is a not joke take C# seriously");

        var jokeOutputMock = new Mock<IJokeOutput>();

        Jester jester = new(jokeServiceMock.Object, jokeOutputMock.Object);

        // Act
        jester.TellJoke();

        // Assert
        jokeOutputMock.Verify(joke => joke.OutputJoke("This is a not joke take C# seriously"), 
            Times.Once, "Joke was not written to output");
    }

}