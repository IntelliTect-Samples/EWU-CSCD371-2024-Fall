using System;
using Xunit;
using Interfaces;

namespace CanHazFunny.Tests;


public class JesterTests
{

    [Fact]
    public void JokeService_CallGetJoke_ReturnsJokeNotNullOrEmpty()
    {
        // Arrange
        JokeService jokeService = new JokeService();

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

        JokeService jokeServ = new JokeService();
        IJokeService jokeService = jokeServ;
        ConsoleJokeOutput jokeOutput = new ConsoleJokeOutput();
        IJokeOutput jokeOutputLog = jokeOutput;

        Jester jester = new Jester(jokeService, jokeOutputLog);

        // Act

        string joke = jester.TellJoke();
        bool isJoke = !string.IsNullOrEmpty(joke);

        // Assert
        Assert.True(isJoke, "This returns a string");
    }
}
