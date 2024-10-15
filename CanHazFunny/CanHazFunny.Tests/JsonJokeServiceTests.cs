using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests;


public class JsonJokeServiceTests
{
    [Fact]
    public void GetJoke_NoArgs_ReturnsJoke()
    {
        // Arrange
        JsonJokeService service = new();
        string joke;

        // Act
        joke = service.GetJoke();

        // Assert
        Assert.NotNull(joke);
        Assert.NotEqual("", joke);
        //Assert.AreEqual("hi", joke); //Uncomment line to see result
    }

    [Theory]
    [InlineData("{ \"joke\": \"A joke here!\" }", "A joke here!")]
    public void ParseJsonJoke_ValidJson_ReturnsString(string jsonString, string expected)
    {
        // Arrange
        JsonJokeService service = new();
        string? response;

        // Act
        response =service.ParseJokeFromJsonString(jsonString);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(expected, response);
        //Assert.AreEqual("expected:"+expected, response); //Uncomment line to see result
    }
}
