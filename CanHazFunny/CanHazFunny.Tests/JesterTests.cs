using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests;


public class JesterTests
{
    [Fact]
    public void ClassCreation_CreateNewInstance_Success()
    {
        // Arrange

        // Act
        Jester jester = new();

        // Assert
        Assert.NotNull(jester);
    }

    [Fact]
    public void ClassCreation_PassedNullToDisplayJokesAndJokeService_ThrowsException()
    {
        // Arrange
        //IDisplayJokes displayJokes = new DisplayJokes();


        // Act


        // Assert
        Assert.Throws<ArgumentNullException>(() => new Jester(null, null));

    }
}
