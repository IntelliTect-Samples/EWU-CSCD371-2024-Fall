using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CanHazFunny.Tests;

    
    public class DisplayJokesTests
    {

    [Fact]
    public void DisplayJokeInterface_CreateMokConcreteClass_Success()
    {
        // Arrange
        var displayJokes = new Moq.Mock<IDisplayJokes>();
        displayJokes.Setup(x => x.OutputJoke()).Returns("Why did the chicken cross the road? To get to the other side.");

        // Act
        var joke = displayJokes.Object.OutputJoke();

        // Assert
        Assert.Equal("Why did the chicken cross the road? To get to the other side.", joke);
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


    //[Theory]
    //[InlineData("Why did the chicken cross the road? To get to the other side.")]
    //public void DisplayJoke_GivenString_ProduceOutput(string joke)
    //{
    //    //Arrange


    //    StringWriter? consoleOutput;
    //    using (consoleOutput = new StringWriter())
    //    {
    //        Console.SetOut(consoleOutput);

    //        //Act

    //        Console.Out.Flush();
    //    }

    //    //Assert
    //    string output = consoleOutput.ToString().Trim();
    //    Assert.Equal(joke, output);

    //}
}