using Xunit;
using System;
using Moq;


namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]

    public void TellJoke_JokeAquired_Sucess()

    { 
        //Arrange
        var mockJokeService = new Mock<IJokeService>();
        var mockOutputService = new Mock<IOutputService>();

        mockJokeService.Setup(foo => foo.GetJoke()).Returns("*put funny joke here*");

        var jester = new Jester(mockJokeService.Object, mockOutputService.Object);
        //Act

        jester.TellJoke();
        //Assert
        mockOutputService.Verify(foo => foo.WriteJoke("*put funny joke here*"), Times.Once);

    }

    [Fact]
    public void Jester_OutputSetNull_ArgumentNullExecption()
    {
        //Arrange
        //Act
        //Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(new JokeService(), null));

    }

    [Fact]
    public void Jester_JokeSetNull_ArgumentNullExecption()
    {
        //Arrange
        //Act
        //Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(null, new OutputService()));

    }

    [Fact]
    public void TellJoke_ReturnChuckNorris_GrabsAnotherJoke() 
    {
        //Arrange
        var mockJokeService = new Mock<IJokeService>();
        var mockOutputService = new Mock<IOutputService>();

        mockJokeService.SetupSequence(foo => foo.GetJoke()).Returns("*put not funny Chuck Norris joke here*").Returns("*put Really funny joke here*");

        var jester = new Jester(mockJokeService.Object, mockOutputService.Object);

        //Act
        jester.TellJoke();

        //Assert
        mockOutputService.Verify(foo => foo.WriteJoke("*put Really funny joke here*"), Times.Once);
        mockOutputService.Verify(foo => foo.WriteJoke("*put not funny Chuck Norris joke here*"), Times.Never);
    }

}


//Arrange
//Act
//Assert
