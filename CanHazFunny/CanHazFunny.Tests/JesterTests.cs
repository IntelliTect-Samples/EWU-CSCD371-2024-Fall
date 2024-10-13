using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_JokeService_PrintsJoke()
    {
        //Arrange
        
        Jester shaco = new( new DisplayService(), new JokeService());
        StringWriter consoleOut = new();
        string outString = consoleOut.ToString();
        //Act

        Console.SetOut(consoleOut);
        shaco.TellJoke();

        //Assert
        Assert.NotNull(outString);
        Assert.NotEmpty(outString);
    }

    [Fact]
    public void Constructor_ThrowsArgument_IfServiceIsNull()
    {
        //Arrange
        IJokeService jokeService = new JokeService();

        //Act and Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new Jester(null!, jokeService));
        Assert.Equal("dispalyService", exception.ParamName);
    }
}