using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void GetJoke_ReturnJoke_WhenApiReturnIsValid()
    {
        // Arrange
        JokeService jokeService = new();
        // Act
        string joke = jokeService.GetJoke();
        // Assert
        Assert.NotNull(joke);
    }
}
