using Xunit;
using Moq;
using System;
using System.IO;
namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void OutputJoke_NullCheck()
    {
         Assert.Throws<ArgumentNullException>(() =>  new Jester(null!, new JokeService()) );
    }
    [Fact]
    public void JokeService_NullCheck()
    {
         Assert.Throws<ArgumentNullException>(() =>  new Jester(new OutputJokes(), null!) );
    }
    [Fact]
    public void Menu_SwitchCase_PrintsOnCL()
    {
      // Arrange
    var stringWriter = new StringWriter();
    Console.SetOut(stringWriter);
    var input = "4\n1";
    Console.SetIn(new StringReader(input));
    // Act
    Menu.ShowMenu(); 
    // Assert
    var output = stringWriter.ToString();
    Assert.Contains("Select the format:", output);
    Assert.Contains("1. JSON", output);
    Assert.Contains("2. HTTP", output);
    Assert.Contains("3. Quit", output);
    Assert.Contains("Invalid choice. Please try again.", output);
    }
    [Fact]
    public void GetChoice_InvalidInput_ShouldPromptAgain()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var input = "invalid\n1\n";
        Console.SetIn(new StringReader(input));
        // Act
        Menu.ShowMenu();
        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Invalid input. Please enter a valid choice.", output);
        Assert.Contains("Select the format:", output);
        Assert.Contains("1. JSON", output);
    }
    [Fact]
    public void TellJoke_Verify()
    {
        // Arrange
       var mockJokeService = new Mock<IJokeService>();
       var mockOutputJokes = new Mock<IOutputJokes>();
        string expectedJoke = "Do you know the muffin man?";
        mockJokeService.SetupSequence(joke => joke.GetJoke()).Returns(expectedJoke);
        Jester jester= new (mockOutputJokes.Object, mockJokeService.Object);
        // Act
        jester.TellJoke();
        // Assert
        mockJokeService.Verify(joke => joke.GetJoke(), Times.Once);
        mockOutputJokes.Verify(outJoke => outJoke.Output(expectedJoke), Times.Once);
    }

    [Fact]
    public void TellJokeJson_Verify()
    {
        // Arrange
        var mockJokeService = new Mock<IJokeService>();
       var mockOutputJokes = new Mock<IOutputJokes>();
        string expectedJokeJson = "{\"joke\":\"What is a mermaids favorite dessert? a spongecake.\"}";
        mockJokeService.Setup(jokeJson => jokeJson.GetJokeJson()).Returns(expectedJokeJson);
        Jester jester= new (mockOutputJokes.Object, mockJokeService.Object);
        // Act
        jester.TellJokeJson();

        // Assert
        mockJokeService.Verify(jokeJson => jokeJson.GetJokeJson(), Times.Once);
        mockOutputJokes.Verify(outJokeJson => outJokeJson.Output(expectedJokeJson), Times.Once);
    }
        [Fact]
    public void ChuckCheckJson_ReturnsJoke()
    {
        // Arrange
        JokeService jokeService= new();
        string inputJoke = "{\"joke\": \"Where does a mermaid sleep? In her seabed!\"}";
        // Act
        var result = jokeService.ChuckCheckJson(inputJoke);

        // Assert
        Assert.Equal("Where does a mermaid sleep? In her seabed!", result);
    }
        [Fact]
    public void ChuckCheck_ReturnsJoke()
    {
        // Arrange
        JokeService jokeService= new();
        string inputJoke = "Why do mermaids sing? To practice their scales!";
        // Act
        var result = jokeService.ChuckCheck(inputJoke);

        // Assert
        Assert.Equal("Why do mermaids sing? To practice their scales!", result);
    }
}
