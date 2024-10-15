
using System;
using Xunit;
using Interfaces;
using Moq;

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

        JokeService jokeServ = new ();
        IJokeService jokeService = jokeServ;
        ConsoleJokeOutput jokeOutput = new ();
        IJokeOutput jokeOutputLog = jokeOutput;

        Jester jester = new (jokeService, jokeOutputLog);

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
        JokeService jokeServ = new ();
        IJokeService jokeService = jokeServ;
        ConsoleJokeOutput jokeOutput = new ();
        IJokeOutput jokeOutputLog = jokeOutput;

        Jester jester = new (jokeService, jokeOutputLog);

        // Act
        string joke = jester.TellJoke(); //Reduce to lower to prevent API errors.
        bool noChuckNorris = !(joke.Contains("chuck norris", StringComparison.InvariantCultureIgnoreCase)); // Will return TRUE if it does NOT contain chuck or norris.

        // Assert
        Assert.True(noChuckNorris, "Joke contains Chuck Norris");
    }
    
    [Fact]
    public void JesterConstructor_NullJokeService_ThrowsArgumentNullException()
    {
        // Arrange
        IJokeOutput jokeOutput = new ConsoleJokeOutput();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, jokeOutput));
    }

    [Fact]
    public void JesterConstructor_NullJokeOutput_ThrowsArgumentNullException()
    {
        // Arrange
        IJokeService jokeService = new JokeService();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(jokeService, null!));
    }

    [Fact]
    public void TellJoke_JokeServiceReturnsNull_ThrowsException()
    {
        // Arrange
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.Setup(js => js.GetJoke()).Returns((string)null!);
        var mockJokeOutput = new Mock<IJokeOutput>();
        var jester = new Jester(mockJokeService.Object, mockJokeOutput.Object);

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => jester.TellJoke());
    }
}
