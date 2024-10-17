using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeOutputTests
{
    [Fact]
    public void WriteJoke_CalledwithJoke_WritesJokeToConsole()
    {
        // Arrange
        var jokeOutput = new JokeOutput();
        var joke = "This is a super funny joke";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        jokeOutput.WriteJoke(joke);

        // Assert
        Assert.Equal(joke, stringWriter.ToString().Trim());

        // Cleanup
        Console.SetOut(Console.Out);
    }
}
