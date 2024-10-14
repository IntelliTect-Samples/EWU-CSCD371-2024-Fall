using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;


public class DisplayJokesTests
{

    [Fact]
    public void DisplayJokeInterface_CreateMokConcreteClass_Success()
    {
        // Arrange
        var displayJokes = new Moq.Mock<IDisplayJokes>();

        // Act

        // Assert
        Assert.NotNull(displayJokes);
    }

    [Fact]
    public void ClassCreation_CreateNewInstance_Success()
    {
        // Arrange
        DisplayJokes displayJokes = new();

        // Act


        // Assert
        Assert.NotNull(displayJokes);
    }


    [Theory]
    [InlineData("Why did the chicken cross the road? To get to the other side.")]
    public void OutputJoke_GivenString_ProduceOutput(string joke)
    {
        //Arrange
        DisplayJokes displayJokes = new();


        StringWriter consoleOutput;
        using (consoleOutput = new StringWriter())
        {

            Console.SetOut(consoleOutput);

            //Act
            displayJokes.OutputJoke("Why did the chicken cross the road? To get to the other side.");

            Console.Out.Flush();
        }

        //Assert
        string output = consoleOutput.ToString().Trim();
        Assert.Equal(joke, output);

    }
}