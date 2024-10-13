using System;
using Xunit;

namespace CanHazFunny.Tests;


public class JesterTests
{

    [Fact]
    public void TellJoke_ShouldReturnJoke()
    {
        // Arrange
        JokeService jokeService = new JokeService();

        // Act
        string joke = jokeService.GetJoke();
        bool isJoke = !string.IsNullOrEmpty(joke);

        // Assert
        Assert.True(isJoke, "Joke is there");
    }




}
