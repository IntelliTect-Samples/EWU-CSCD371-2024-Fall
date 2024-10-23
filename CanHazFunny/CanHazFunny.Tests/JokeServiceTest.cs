using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTest
{
    [Fact]
    public void IJokeService_AquireJoke_ReturnsExpectedJoke()
    {
        //Arrange
        var mockjokeService = new Mock<IJokeService>();

        string expectedJoke = "*Refrence to Other Funny Joke*";

        mockjokeService.Setup(service => service.GetJoke()).Returns(expectedJoke);
        //Act
        string retreviedJoke = mockjokeService.Object.GetJoke();

        //Assert
        Assert.Equal(expectedJoke, retreviedJoke);
    }

}
