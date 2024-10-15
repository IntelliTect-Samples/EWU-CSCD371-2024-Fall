using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
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