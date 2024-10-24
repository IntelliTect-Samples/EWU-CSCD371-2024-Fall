using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void GetJoke_ReturnsJoke_Success() 
    {
        var jokeService = new JokeService();
        var joke = jokeService.GetJoke();
        Assert.NotNull(joke);
    }
}
