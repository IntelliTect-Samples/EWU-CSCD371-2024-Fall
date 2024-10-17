using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void GetJoke_NoArgs_ReturnsJoke()
    {
        // Arrange
        JokeService service = new();
        string joke;

        // Act
        joke = service.GetJoke();

        // Assert
        Assert.NotNull(joke);
        Assert.NotEqual("", joke);
        Assert.NotEmpty(joke);
    }
}