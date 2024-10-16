using System;
using Xunit;
using Moq;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_JokeRetrieved_SuccessfullyReceived()

    {
        //Arrange
        var serviceMock = new Mock<IJokeService>();
        var outputMock = new Mock<IOutputService>();


        serviceMock.Setup(foo => foo.GetJoke()).Returns("Why is 6 afraid of 7? Because 7 ate 9!");

        var jester = new Jester(outputMock.Object, serviceMock.Object);

        //Act
        jester.TellJoke();

        //Assert
        outputMock.Verify(foo => foo.WriteJoke("Why is 6 afraid of 7? Because 7 ate 9!"), Times.Once());
    }
}