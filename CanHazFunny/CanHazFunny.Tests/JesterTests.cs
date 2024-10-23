using Xunit;
using System;
using Moq;


namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
#pragma warning disable CA1707 // Identifiers should not contain underscores
    public void TellJoke_JokeAquired_Sucess()
#pragma warning restore CA1707 // Identifiers should not contain underscores
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
