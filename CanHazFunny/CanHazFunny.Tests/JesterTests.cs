using Xunit;
using Moq;
using System;
using System.IO;
namespace CanHazFunny.Tests;

public class JesterTests
{
     private readonly Mock<OutputJokes> mockOutputJokes;
    private readonly Mock<JokeService> mockJokeService;
    private readonly Jester jester;

    public JesterTests()
    {
        mockOutputJokes = new Mock<OutputJokes>();
        mockJokeService = new Mock<JokeService>();
        jester = new Jester(mockOutputJokes.Object, mockJokeService.Object);
    }
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
        //Arrange
        var stringWriter = new StringWriter();
        // Act
        Menu.ShowMenu();
        Console.SetOut(stringWriter);
        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Select the format:", output);
        Assert.Contains("1. JSON", output);
        Assert.Contains("2. HTTP", output);
        Assert.Contains("3. Quit", output);
    }
    [Fact]
    public void TellJoke_Verify()
    {
        // Arrange
        string expectedJoke = "";
        mockJokeService.SetupSequence(joke => joke.GetJoke()).Returns(expectedJoke);
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
        string expectedJokeJson = "{\"joke\":\"free\"}";
        mockJokeService.Setup(jokeJson => jokeJson.GetJokeJson()).Returns(expectedJokeJson);

        // Act
        jester.TellJokeJson();

        // Assert
        mockJokeService.Verify(jokeJson => jokeJson.GetJokeJson(), Times.Once);
        mockOutputJokes.Verify(outJokeJson => outJokeJson.Output(expectedJokeJson), Times.Once);
    }
}
