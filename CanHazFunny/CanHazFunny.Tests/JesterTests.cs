using Xunit;
using CanHazFunny;

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
        Assert.Throws<System.ArgumentNullException>(
            () => new Jester(null!, new ConsoleJoke()));
    }

    [Fact]
    public void JokeTeller_SetJokeTellerNull_ArgumentNullException()
    {
        Assert.Throws<System.ArgumentNullException>(
            () => new Jester(new JokeService(), null!));
    }

    [Fact]
    public void TellJoke_GetsJokeWithNoChuckNorris_PrintsJoke()
    {
        Jester jester = new(new JokeService(), new ConsoleJoke());
        jester.TellJoke();
        Assert.DoesNotContain("Chuck Norris", System.Console.Out.ToString());
    }
}
