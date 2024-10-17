using System;
using Xunit;
using Moq;

namespace CanHazFunny.Tests;

public class JesterTests
{

    [Fact]
    public void JokeOutput_ServiceSetNull_ArgumentNullException()
    {
        //Arrange

        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(() =>  new Jester(new JokeOutput(), null!) );
    }

    [Fact]
    public void JokeOutput_OutputSetNull_ArgumentNullException()
    {
        //Arrange

        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new JokeService()));
    }

    [Fact]
    public void ToLower_PassedValidString_ReturnsLowercaseString()
    {
        //Arrange
        string uppercase = "THISISSOMEUPPERCASE";

        //Act

        //Assert
        Assert.Equal("thisissomeuppercase", uppercase.ToLowerInvariant());
    }

    [Fact]
    public void TellJoke_ChuckNorrisJokeRetrieved_JokeNotContainsChuckNorris()
    {
        //Arrange
        var serviceMock = new Mock<IJokeService>();
        var outputMock = new Mock<IJokeOutput>();

        serviceMock.SetupSequence(foo => foo.GetJoke()).Returns("ULTIMATE ChUck NorrIS")
            .Returns("Valid Joke");

        var jest = new Jester(outputMock.Object, serviceMock.Object);

        //Act
        jest.TellJoke();
        
        //Assert
        outputMock.Verify(foo => foo.WriteJoke("Valid Joke"), Times.AtLeastOnce());
        outputMock.Verify(foo => foo.WriteJoke("ULTIMATE ChUck NorrIS"), Times.Never());

    }

}