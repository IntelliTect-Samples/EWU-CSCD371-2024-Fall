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

}


//Arrange
//Act
//Assert
