using Xunit;
using System;
using System.Collections.Generic;
using System.IO;
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
    public void Getters_DoGettersReturnCorrectValues_Success()
    {
        // Arrange
        IJokeService jokeService = new JokeService();
        IDisplayJokes displayJokes = new DisplayJokes();
        Jester jester = new(jokeService, displayJokes);

        // Act
        IJokeService jokeServiceResult = jester.JokeService;
        IDisplayJokes displayJokesResult = jester.DisplayJokes;

        // Assert
        Assert.Equal(jokeService, jokeServiceResult);
        Assert.Equal(displayJokes, displayJokesResult);
    }

    [Fact]
    public void Setters_DoSettersSetCorrectValues_Success()
    {
        // Arrange
        IJokeService jokeService = new JokeService();
        IDisplayJokes displayJokes = new DisplayJokes();
        Jester jester = new(jokeService, displayJokes);

        // Act
        IJokeService newJokeService = new JokeService();
        IDisplayJokes newDisplayJokes = new DisplayJokes();
        jester.JokeService = newJokeService;
        jester.DisplayJokes = newDisplayJokes;

        // Assert
        Assert.Equal(newJokeService, jester.JokeService);
        Assert.Equal(newDisplayJokes, jester.DisplayJokes);
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
        Assert.NotNull(joke);
        Assert.NotEmpty(joke);
    }

    [Fact]
    public void JesterTellJoke_ReceivesJoke_PrintsJokeToConsole()
    {
        //arrange
        StringWriter consoleOutput;
        using (consoleOutput = new StringWriter())
        {
            Console.SetOut(consoleOutput);

            IJokeService jokeService = new JokeService();
            IDisplayJokes displayJokes = new DisplayJokes();
            Jester jester = new(jokeService, displayJokes);

            //act
            jester.TellJoke();

            Console.Out.Flush();
        }
        //assert
        string output = consoleOutput.ToString().Trim();
        Assert.NotEmpty(output);
    }

    [Fact]
    public void JesterTellJoke_ScreensForChuckNorris_NoChuckJokes()
    {
        for (int i = 0; i < 3; i++)
        {
            // Arrange
            StringWriter consoleOutput;
            using (consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                IJokeService jokeService = new JokeService();
                IDisplayJokes displayJokes = new DisplayJokes();
                Jester jester = new(jokeService, displayJokes);

                // Act
                jester.TellJoke();

                Console.Out.Flush();
            }

            // Assert
            string output = consoleOutput.ToString().Trim();
            Assert.DoesNotContain("Chuck", output);
            Assert.DoesNotContain("Norris", output);
        }
    }

}
