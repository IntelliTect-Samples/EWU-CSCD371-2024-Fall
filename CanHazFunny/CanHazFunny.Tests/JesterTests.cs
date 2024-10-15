using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_ShouldReturnJoke()
    {
        // Arrange
        Jester jester = new();
        // Act
        jester.TellJoke();
        // Assert
        Assert.NotNull(jester);
    }
    [Fact]
    public void TellJokeJson_ShouldReturnJoke()
    {
        //Arrange
        Jester jester = new();
        //Act
        jester.TellJokeJson();
        //Assert
        Assert.NotNull(jester);
    }
    
    [Fact]
    public void GetJoke_ShouldReturnJoke()
    {
        //Arrange
        JokeService jokeService= new();
        string joke;
        //Act
        joke = jokeService.GetJoke();
        //Assert
        Assert.NotNull(joke);
    }
      [Fact]
    public void GetJokeJson_ShouldReturnJoke()
    {
        //Arrange
       JokeService jokeService= new();
       string joke;
        //Act
       joke = jokeService.GetJokeJson();
        //Assert
        Assert.NotNull(joke);
    }
    [Fact]
    public void Main_WrongInput_ReturnString()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var inputs = new[] { "A", "Y" };
        Console.SetIn(new StringReader(string.Join(Environment.NewLine, inputs)));
        // Act
        Program.Main(Array.Empty<string>());
        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Invalid input. Please enter Y or N.", output);
        Assert.Contains("Would you like to hear a joke? (Y/N) or Change formats (F)", output);
    }
   [Fact]
   public void Main_SwitchToJson_SwitchToHttp()
   {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var inputs = new[] { "F", "F" }; 
        Console.SetIn(new StringReader(string.Join(Environment.NewLine, inputs)));
        // Act
        Program.Main(Array.Empty<string>());
        // Assert
        var output = stringWriter.ToString();
        Assert.Contains("Format changed to: Json" + System.Environment.NewLine, output);
        Assert.Contains("Would you like to hear a joke? (Y/N) or Change formats (F)", output);
        Assert.Contains("Format changed to: Http" + System.Environment.NewLine, output);
        Assert.Contains("Would you like to hear a joke? (Y/N) or Change formats (F)", output);
   }
}
