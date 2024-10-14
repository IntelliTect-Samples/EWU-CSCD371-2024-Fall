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
        var originalConsoleOut = Console.Out;
        try
        {
            Jester shaco = new(new DisplayService(), new JokeService());
            StringWriter consoleOut = new();
            Console.SetOut(consoleOut);

            //Act

            shaco.TellJoke();
            string outString = consoleOut.ToString();

            //Assert
            Assert.NotNull(outString);
            Assert.NotEmpty(outString);
        }
        finally
        {
            Console.SetOut(originalConsoleOut);
        }
    }

    [Fact]
    public void Constructor_ThrowsArgument_IfDisplayServiceIsNull()
    {
        //Arrange
        IJokeService jokeService = new JokeService();

        //Act and Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new Jester(null!, jokeService));
        Assert.Equal("dispalyService", exception.ParamName);
    }

    [Fact]
    public void Constructor_ThrowsArgument_IfJokeServiceIsNull()
    {
        // Arrange
        IDisplayJokes displayJokes = new DisplayService();

        // Act and Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new Jester(displayJokes, null!));
        Assert.Equal("jokeService", exception.ParamName);
    }

    [Fact]
    public void TellJoke_DoesNotPrint_IfJokeContainsChuckNorris()
    {
        //Arrange
        var displayService = new Mock<IDisplayJokes>();
        var jokeServiceMock = new Mock<IJokeService>();
        jokeServiceMock.Setup(jokeService => jokeService.GetJoke()).Returns("Chuck Norris can delete the Recycling Bin.");

        var shaco = new Jester(displayService.Object, jokeServiceMock.Object);

        //Act
        shaco.TellJoke();

        //Assert
        displayService.Verify(display => display.DisplayJoke(It.IsAny<string>()), Times.Never);
    }
}