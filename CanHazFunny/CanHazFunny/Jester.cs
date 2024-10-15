
using System;

namespace CanHazFunny.Tests;

public class Jester
{
    public IDisplayJokes JokeDisplayer { get; }
    public ITellJokes JokeTeller { get; }

    public Jester(IDisplayJokes jokeDisplayer, ITellJokes jokeTeller)
    {
        JokeDisplayer = jokeDisplayer;
        JokeTeller = jokeTeller;
    }
}