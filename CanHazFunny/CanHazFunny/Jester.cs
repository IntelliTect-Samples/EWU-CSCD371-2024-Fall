
using System;

namespace CanHazFunny.Tests;

public class Jester
{
    public IDisplayJokes JokeDisplayer { get; }
    public ITellJokes JokeTeller { get; }

    public Jester(IDisplayJokes jokeDisplayer, ITellJokes jokeTeller)
    {
        if (jokeDisplayer is null) jokeDisplayer = new DisplayService();
        JokeDisplayer = jokeDisplayer;

        JokeTeller = jokeTeller;
    }
}