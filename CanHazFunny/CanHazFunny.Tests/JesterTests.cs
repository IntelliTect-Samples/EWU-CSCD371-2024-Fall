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

}
