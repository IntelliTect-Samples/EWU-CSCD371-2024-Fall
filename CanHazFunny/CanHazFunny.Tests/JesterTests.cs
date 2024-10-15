using Moq;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void TellJoke_ReturnsValidJoke_JokePrinted()
    {
        // Arrange
        var mockJokeService = new Mock<IJokeService>();
        var mockOutputService = new Mock<IOutputService>();

        string outputJoke = string.Empty;
        mockJokeService.Setup(js => js.GetJoke()).Returns("Why did the chicken cross the road? To get to the other side!");
        mockOutputService.Setup(os => os.WriteJoke(It.IsAny<string>())).Callback<string>(joke => outputJoke = joke);
        Jester jester = new(mockOutputService.Object, mockJokeService.Object);

        // Act
        jester.TellJoke();

        // Assert
        Assert.Equal("Why did the chicken cross the road? To get to the other side!", outputJoke);
    }

    [Fact]
    public void TellJoke_SkipsChuckNorrisJoke_ReturnsValidJoke()
    {
        // Arrange
        var mockJokeService = new Mock<IJokeService>();
        var mockOutputService = new Mock<IOutputService>();

        string outputJoke = string.Empty;
        mockJokeService.SetupSequence(js => js.GetJoke())
            .Returns("Chuck Norris walks into a bar.")
            .Returns("Why did the chicken cross the road? To get to the other side!");
        mockOutputService.Setup(os => os.WriteJoke(It.IsAny<string>()))
            .Callback<string>(joke => outputJoke = joke);
        Jester jester = new(mockOutputService.Object, mockJokeService.Object);

        // Act
        jester.TellJoke();

        // Assert
        Assert.Equal("Why did the chicken cross the road? To get to the other side!", outputJoke);
    }
}
