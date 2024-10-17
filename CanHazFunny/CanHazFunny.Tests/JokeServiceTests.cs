using System;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{

    [Fact]
    public void GetJoke_Called_ReturnsNotNullOrEmpty()
    {
        //Arrange
        var service = new JokeService();

        //Act

        //Assert
        Assert.NotNull(service.GetJoke());
        Assert.NotEmpty(service.GetJoke());
    }

    [Fact]
    public void GetJoke_Called_ReturnsValidString()
    {
        //Arrange
        var service = new JokeService();

        //Act

        //Assert
        Assert.IsType<string>(service.GetJoke());
    }

}