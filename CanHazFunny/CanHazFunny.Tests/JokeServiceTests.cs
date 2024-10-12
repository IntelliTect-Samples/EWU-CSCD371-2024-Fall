using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests;


public class JokeServiceTests
{
    [Fact]
    public void GetJoke_NoArgs_ReturnsJoke()
    {
        // Arrange
        JokeService service = new();
        string joke;

        // Act
        joke = service.GetJoke();

        // Assert
        Assert.NotNull(joke);
        Assert.NotEqual("", joke);
        //Assert.AreEqual("hi", joke); //Uncomment line to see result
    }
}
