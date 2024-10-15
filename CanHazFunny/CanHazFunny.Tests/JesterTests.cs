using Xunit;
using CanHazFunny;
using System;
using System.IO;

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
    public void TellJoke_GetsJokeWithNoChuckNorris_PrintsJoke()
    {
        StringWriter writer = new();
        Console.SetOut(writer);

        Jester jester = new(new JokeService(), new ConsoleJoke());
        jester.TellJoke();

        Assert.DoesNotContain("Chuck Norris", writer.ToString());
    }
}
