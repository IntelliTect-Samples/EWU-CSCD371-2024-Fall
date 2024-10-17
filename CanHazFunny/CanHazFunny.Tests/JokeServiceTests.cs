using Xunit;
using System;
using System.Text.Json.Nodes;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void JokeServiceInterface_CreateMockConcreteClass_Success()
    {
        // Arrange
        var jokeService = new Moq.Mock<IJokeService>();
        jokeService.Setup(x => x.GetJoke()).Returns("Test Joke haha");

        // Act
        var joke = jokeService.Object.GetJoke();

        // Assert
        Assert.Equal("Test Joke haha", joke);
    }

    [Fact]
    public void FormatJoke_NullInput_ThrowsException()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => JokeService.FormatJoke(null!));
    }

    [Fact]
    public void ExtractJoke_NullJokeNode_ReturnsDefaultMessage()
    {
        // Arrange
        JsonNode? jokeNode = null;

        // Act
        string result = JokeService.ExtractJoke(jokeNode);

        // Assert
        Assert.Equal("No joke found!", result);
    }

    [Fact]
    public void ExtractJoke_JokeNodeExistsButJokeKeyIsNull_ReturnsDefaultMessage()
    {
        // Arrange
        var jokeNode = JsonNode.Parse("{ \"joke\": null }");

        // Act
        string result = JokeService.ExtractJoke(jokeNode);

        // Assert
        Assert.Equal("No joke found!", result);
    }

    [Fact]
    public void ExtractJoke_JokeNodeMissingJokeKey_ReturnsDefaultMessage()
    {
        // Arrange
        var jokeNode = JsonNode.Parse("{ }");

        // Act
        string result = JokeService.ExtractJoke(jokeNode);

        // Assert
        Assert.Equal("No joke found!", result);
    }

    [Fact]
    public void ExtractJoke_JokeNodeHasValidJoke_ReturnsJoke()
    {
        // Arrange
        var jokeNode = JsonNode.Parse("{ \"joke\": \"Test Joke haha\" }");

        // Act
        string result = JokeService.ExtractJoke(jokeNode);

        // Assert
        Assert.Equal("Test Joke haha", result);
    }
}

