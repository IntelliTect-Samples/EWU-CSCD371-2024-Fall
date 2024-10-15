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
        JokeService jokeService = new ();

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

    [Fact]
    public void JesterTellJoke_NoChuckNorris_ReturnsTrue()
    {
        // Arrange
        JokeService jokeServ = new JokeService();
        IJokeService jokeService = jokeServ;
        ConsoleJokeOutput jokeOutput = new ConsoleJokeOutput();
        IJokeOutput jokeOutputLog = jokeOutput;

        Jester jester = new Jester(jokeService, jokeOutputLog);

        // Act
        string joke = jester.TellJoke().ToLower(); //Reduce to lower to prevent API errors.
        bool NoChuckNorris = !(joke.Contains("chuck") || joke.Contains("chuck")); // Will return TRUE if it does NOT contain chuck or norris.

        // Assert
        Assert.True(NoChuckNorris, "Joke contains Chuck Norris");
    }
}
