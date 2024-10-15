using Moq;
using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void Constructor_JsonJokeService_CreatesValidJester()
    {

        //Arrange
        DisplayService displayService = new();
        JsonJokeService jsonJokeService = new();

        //Act
        Jester jester = new Jester(displayService, jsonJokeService);

        //Assert
        Assert.NotNull(jester);
    }
}