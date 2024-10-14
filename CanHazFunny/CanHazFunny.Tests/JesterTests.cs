using Xunit;
using static CanHazFunny.JokeService;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_ShouldReturnJoke()
    {
        // Arrange
        Jester jester = new();

        // Act
        string joke = jester.TellJoke();

        // Assert
        Assert.NotNull(joke);
    }
    [Fact]
    public void TellJokeJson_ShouldReturnJoke()
    {
        //Arrange
        Jester jester = new();
        //Act
        string json = jester.TellJokeJson();
        //Assert
        Assert.NotNull(json);
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
   
}
