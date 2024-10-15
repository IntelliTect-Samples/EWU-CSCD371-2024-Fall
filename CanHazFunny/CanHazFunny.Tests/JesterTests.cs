using Moq;
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
        Jester jester = new Jester(displayService, jsonJokeService);

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
        Jester jester = new Jester(displayService, jsonJokeService);

        //Assert
        Assert.NotNull(jester);
    }

    [Fact]
    public void Constructor_DisplayServiceNull_CreatesValidJester()
    {
        //Arrange
        JsonJokeService jsonJokeService = new();

        //Act
        Jester jester = new Jester(null!, jsonJokeService);

        //Assert
        Assert.NotNull(jester);
        Assert.NotNull(jester.JokeDisplayer);
        Assert.NotNull(jester.JokeTeller);
    }

    [Fact]
    public void Constructor_ITellJokesNull_CreatesValidJester()
    {
        //Arrange
        var displayservice = new DisplayService();

        //Act
        Jester jester = new Jester(displayservice, null!);

        //Assert
        Assert.NotNull(jester);
        Assert.NotNull(jester.JokeDisplayer);
        Assert.NotNull(jester.JokeTeller);
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
        Assert.NotNull(jester);
    }
}