using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using Xunit;

namespace CanHazFunny.Tests;

public class IJokeServiceTests
{
    [Fact]
    public void GetJoke_NullJoke_ThrowException()
    {
        // Arrange
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.Setup(js => js.GetJoke()).Throws(new ArgumentNullException());

        // Assert
        Assert.Throws<ArgumentNullException>(() => mockJokeService.Object.GetJoke());
    }

    [Fact]
    public void GetJoke_StandardJoke_Success()
    {
        // Arrange
        string outputJoke = "Very funny joke"!;
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.Setup(js => js.GetJoke()).Returns(outputJoke);

        // Assert
        Assert.Equal(outputJoke, mockJokeService.Object.GetJoke());
    }
}
