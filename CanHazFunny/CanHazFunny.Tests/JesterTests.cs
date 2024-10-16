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

    [Fact]
    public void TellJoke_ChuckNorrisJokeRetrieved_NewJokeChosenAndOutputCorrectly()
    {
        //Arrange
        var serviceMock = new Mock<IJokeService>();
        var outputMock = new Mock<IOutputService>();

        serviceMock.SetupSequence(foo => foo.GetJoke())
            .Returns("Chuck Norris joke")
            .Returns("Valid joke");        

        var jester = new Jester(outputMock.Object, serviceMock.Object);

        //Act
        jester.TellJoke();

        //Assert
        outputMock.Verify(foo => foo.WriteJoke("Chuck Norris joke"), Times.Never());
        outputMock.Verify(foo => foo.WriteJoke("Valid joke"), Times.Once());
    }

    [Fact]
    public void Constructor_NullJokeService_ThrowsArgumentNullException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(new Mock<IOutputService>().Object, null));
    }

    [Fact]
    public void Constructor_NullOutputService_ThrowsArgumentNullException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(null, new Mock<IJokeService>().Object));
    }
}