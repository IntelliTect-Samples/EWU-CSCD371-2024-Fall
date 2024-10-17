using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void GetJoke_APICall_ReturnValidJoke()
    {
        // Arrange
        JokeService jokeService = new();
        // Act
        string joke = jokeService.GetJoke();
        // Assert
        Assert.NotNull(joke);
        Assert.NotEmpty(joke);
    }   
}
