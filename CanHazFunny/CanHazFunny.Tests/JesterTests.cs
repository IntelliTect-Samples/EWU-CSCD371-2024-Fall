using Moq;
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
        var displayServiceMock = new Mock<IDisplayJokes>();
        var jokeServiceMock = new Mock<IJokeService>();
        var joke = "Why did the programmer quit his job? Because he didn't get arrays.";

        jokeServiceMock.Setup(jokeService => jokeService.GetJoke()).Returns(joke);
        displayServiceMock.Setup(service => service.DisplayJoke(joke)).Callback<string>(Console.WriteLine);

        var shaco = new Jester(displayServiceMock.Object, jokeServiceMock.Object);

        StringWriter consoleOut = new();
        Console.SetOut(consoleOut);

        //Act

        shaco.TellJoke();
        string outString = consoleOut.ToString();

        //Assert
        Assert.NotNull(outString);
        Assert.Contains(joke, outString);
        Assert.NotEmpty(outString);
    }

    [Fact]
    public void TellJoke_DoesNotPrint_IfJokeContainsChuckNorris()
    {
        //Arrange
        var displayServiceMock = new Mock<IDisplayJokes>();
        var jokeServiceMock = new Mock<IJokeService>();
        var joke = "Chuck Norris can delete the Recycling Bin.";
        jokeServiceMock.Setup(jokeService => jokeService.GetJoke()).Returns(joke);

        var shaco = new Jester(displayServiceMock.Object, jokeServiceMock.Object);

        //Act
        shaco.TellJoke();

        //Assert
        displayServiceMock.Verify(display => display.DisplayJoke(joke), Times.Never);
    }

    [Fact]
    public void DisplayJoke_WhenCalled_PrintsJokeToConsole()
    {
        // Arrange
        var displayService = new DisplayService();
        StringWriter consoleOut = new();
        Console.SetOut(consoleOut);

        // Act
        displayService.DisplayJoke("Test joke");

        // Assert
        string outString = consoleOut.ToString();
        Assert.Contains("Test joke", outString);
    }


    [Fact]
    public void Constructor_ThrowsArgument_IfDisplayServiceIsNull()
    {
        //Arrange
        IJokeService jokeService = new JokeService();

        //Act
        var exception = Assert.Throws<ArgumentNullException>(() => new Jester(null!, jokeService));

        //Assert
        Assert.Equal("dispalyService", exception.ParamName);
    }

    [Fact]
    public void Constructor_ThrowsArgument_IfJokeServiceIsNull()
    {
        // Arrange
        IDisplayJokes displayJokes = new DisplayService();

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => new Jester(displayJokes, null!));

        // Assert
        Assert.Equal("jokeService", exception.ParamName);
    }
}