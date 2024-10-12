using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Theory]
    public void TellJoke_JokeService_PrintsJoke(IJokeService jokeServiceConcreteInstance,IDisplayJokes displayJokesConcreteInstance)
    {
        //Arrange
        
        Jester shaco = new(new JokeService(), new DisplayService());
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
