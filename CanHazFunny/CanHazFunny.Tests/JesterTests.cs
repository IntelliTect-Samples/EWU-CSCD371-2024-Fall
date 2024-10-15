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
        IJokeService jokeService = new JokeService();
        IDisplayJokes displayJokes = new DisplayJokes();

        // Act
        Jester jester = new(jokeService, displayJokes);

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
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, null!));

    }

    [Fact]
    public void ClassCreation_PassedValidClasses_HasValidClasses()
    {
        // Arrange
        string expectedTypeOfJokeService = "CanHazFunny.JokeService";
        string expectedTypeOfDisplayJokes = "CanHazFunny.DisplayJokes";
        IJokeService jokeService = new JokeService();
        IDisplayJokes displayJokes = new DisplayJokes();

        // Act
        Jester jester = new(jokeService, displayJokes);

        // Assert
        Assert.Equal(expectedTypeOfJokeService, jester.JokeService.GetType().ToString());
        Assert.Equal(expectedTypeOfDisplayJokes, jester.DisplayJokes.GetType().ToString());
    }

    [Fact]
    public void JesterGetJoke_HasJoke_Success()
    {
        // Arrange
        IJokeService jokeService = new JokeService();
        IDisplayJokes displayJokes = new DisplayJokes();
        Jester jester = new(jokeService, displayJokes);

        // Act
        string joke = jester.JokeService.GetJoke();

        // Assert
        Console.WriteLine(joke);
        Assert.NotNull(joke);
        Assert.NotEmpty(joke);
    }

    //TODO: Test to see if we can filter Chuck Norris jokes from Jester.GetJoke()
}
