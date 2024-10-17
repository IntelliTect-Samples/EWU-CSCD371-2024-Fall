using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class ConsoleJokeTests
{
    [Fact]
    public void TellJoke_GivenString_Success()
    {
        // Arrange
        var writeString = new StringWriter();
        // Act
        Console.SetOut(writeString);
        ConsoleJoke consoleJoke = new();
        var joke = "This is a joke";
        consoleJoke.TellJoke(joke);
        // Assert
        Assert.Equal(joke + Environment.NewLine, writeString.ToString());
    }
}
