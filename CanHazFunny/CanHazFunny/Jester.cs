using System;

namespace CanHazFunny.Tests;

public class Jester
{
    public IDisplayJokes JokeDisplayer { get; }
    public ITellJokes JokeTeller { get; }

    public Jester(IDisplayJokes jokeDisplayer, ITellJokes jokeTeller)
    {
        JokeDisplayer = jokeDisplayer ?? throw new ArgumentNullException($"{nameof(jokeDisplayer)} cannot be null");

        JokeTeller = jokeTeller ?? throw new ArgumentNullException($"{nameof(jokeTeller)} cannot be null.");
    }

    public void TellJoke()
    {
        string joke = JokeTeller.GetJoke();

        while (joke.Contains("Chuck Norris"))
        {
            joke = JokeTeller.GetJoke();
        }

        JokeDisplayer.DisplayJoke(joke);
    }
}