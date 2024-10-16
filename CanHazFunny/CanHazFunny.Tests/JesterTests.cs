using Xunit;
using CanHazFunny;
using System;
using System.IO;
using Moq;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void JokeService_InitializedJester_Success()
    {
        Jester jester = new(new JokeService(), new ConsoleJoke());
        Assert.Equal(typeof(JokeService), jester.JokeService.GetType());
    }

    [Fact]
    public void JokeTeller_InitializedJester_Success()
    {
        Jester jester = new(new JokeService(), new ConsoleJoke());
        Assert.Equal(typeof(ConsoleJoke), jester.JokeTeller.GetType());
    }

    [Fact]
    public void JokeService_SetJokeServiceNull_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Jester(null!, new ConsoleJoke()));
    }

    [Fact]
    public void JokeTeller_SetJokeTellerNull_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Jester(new JokeService(), null!));
    }

    [Fact]
    public void JokeService_SetNullToInitializedJester_ArgumentNullException()
    {
        Jester jester = new(new JokeService(), new ConsoleJoke());
        Assert.Throws<ArgumentNullException>(
            () => jester.JokeService = null!);
    }

    [Fact]
    public void JokeTeller_SetNullToInitializedJester_ArgumentNullException()
    {
        Jester jester = new(new JokeService(), new ConsoleJoke());
        Assert.Throws<ArgumentNullException>(
            () => jester.JokeTeller = null!);
    }

    [Fact]
    public void TellJoke_PrintsJoke_Success()
    {
        StringWriter writer = new();
        Console.SetOut(writer);

        Jester jester = new(new JokeService(), new ConsoleJoke());
        jester.TellJoke();

        Assert.NotEqual(string.Empty, writer.ToString());
    }

    [Fact]
    public void TellJoke_JokeServiceReturnsNull_NullReferenceException()
    {
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.Setup(x => x.GetJoke()).Returns((string)null!);
        var mockJokeTeller = new Mock<IJokeTeller>();
        Jester jester = new(mockJokeService.Object, mockJokeTeller.Object);

        Assert.Throws<NullReferenceException>(() => jester.TellJoke());
    }

    [Fact]
    public void TellJoke_JokeServiceReturnsChuckNorris_Success()
    {
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.SetupSequence(x => x.GetJoke())
            .Returns("Chuck Norris joke")
            .Returns("Another joke");
        var mockJokeTeller = new Mock<IJokeTeller>();
        Jester jester = new(mockJokeService.Object, mockJokeTeller.Object);

        jester.TellJoke();

        mockJokeTeller.Verify(x => x.TellJoke("Another joke"), Times.Once);
    }
}
