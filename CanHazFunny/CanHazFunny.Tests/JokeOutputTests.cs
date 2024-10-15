using Moq;
using Interfaces;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeOutputTests
{
    [Fact]
    public void OutputJoke_ValidJoke_JokeOutputCalledOnce()
    {
        // Arrange
        var mockJokeOutput = new Mock<IJokeOutput>();
        var joke = "This is a not joke take C# seriously";

        // Act
        mockJokeOutput.Object.OutputJoke(joke);

        // Assert
        mockJokeOutput.Verify(x => x.OutputJoke(joke), Times.Once, "Expected OutputJoke to be called once with the provided joke.");
    }
}