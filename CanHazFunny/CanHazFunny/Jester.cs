using System;

namespace CanHazFunny.Tests;

public class Jester
{
    public IDisplayJokes JokeDisplayer { get; }
    public ITellJokes JokeTeller { get; }

    public Jester(IDisplayJokes jokeDisplayer, ITellJokes jokeTeller)
    {
        if (jokeDisplayer is null)
        {
            JokeDisplayer = jokeDisplayer ?? throw new ArgumentNullException($"{nameof(jokeDisplayer)} cannot be null");
        }
        JokeDisplayer = jokeDisplayer;

        if (jokeTeller is null)
        {
            JokeTeller = jokeTeller ?? throw new ArgumentNullException($"{nameof(jokeTeller)} cannot be null.");
        }
        JokeTeller = jokeTeller;
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