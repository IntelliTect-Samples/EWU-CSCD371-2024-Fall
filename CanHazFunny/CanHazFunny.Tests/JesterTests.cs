using Xunit;
using static CanHazFunny.JokeService;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_ShouldReturnJoke()
    {
        // Arrange
        Jester jester = new();

        // Act
        string joke = jester.TellJoke();

        // Assert
        Assert.NotNull(joke);
    }
}
