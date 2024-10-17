using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class DisplayServiceTests
{
    [Theory]
    [InlineData("Bad Joke Here")]
    public void DisplayJoke_ValidString_DisplaysJoke(string joke)
    {
        //Arrange
        StringWriter consoleOut = new();
        Console.SetOut(consoleOut);
        DisplayService displayService = new();

        //Act
        displayService.DisplayJoke(joke);

        //Assert
        Assert.Equal(consoleOut.ToString().Trim(),joke.Trim());
    }
}