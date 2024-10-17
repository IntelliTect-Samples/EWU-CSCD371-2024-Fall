using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void Constructor_JsonJokeService_CreatesValidJester()
    {
        //Arrange
        DisplayService displayService = new();
        JsonJokeService jsonJokeService = new();

        //Act
        Jester jester = new(displayService, jsonJokeService);

        //Assert
        Assert.NotNull(jester);
    }

    [Fact]
    public void Constructor_JokeService_CreatesValidJester()
    {

        //Arrange
        DisplayService displayService = new();
        JsonJokeService jsonJokeService = new();

        //Act
        Jester jester = new (displayService, jsonJokeService);

        //Assert
        Assert.NotNull(jester);
    }

    [Fact]
    public void Constructor_DisplayServiceNull_ThrowsArgumentNullException()
    {
        //Arrange

        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(() => (new Jester(null!, new JokeService())));
    }

    [Fact]
    public void Constructor_JokeServiceNull_ThrowsArgumentNullException()
    {
        //Arrange

        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(() => (new Jester(new DisplayService(), null!)));
    }

    [Fact]
    public void TellJoke_JokeService_PrintsJoke()
    {
        //Arrange
        Jester jester = new(new DisplayService(), new JokeService());
        TextWriter writer = new StringWriter();
        string? output;
        Console.SetOut(writer);

        //Act
        jester.TellJoke();
        output = writer.ToString();

        //Assert
        Assert.False(String.IsNullOrEmpty(output));
        Assert.NotNull(jester);
    }

    [Fact]
    public void TellJoke_JsonJokeService_PrintsJoke()
    {
        //Arrange
        Jester jester = new(new DisplayService(), new JsonJokeService());
        TextWriter writer = new StringWriter();
        string? output;
        Console.SetOut(writer);

        //Act
        jester.TellJoke();
        output = writer.ToString();

        //Assert
        Assert.False(String.IsNullOrEmpty(output));
        Assert.NotNull(jester);
    }
}