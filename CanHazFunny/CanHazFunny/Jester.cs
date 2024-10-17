namespace CanHazFunny.Tests;

public class Jester
{
    public IDisplayJokes JokeDisplayer { get; }
    public ITellJokes JokeTeller { get; }

    public Jester(IDisplayJokes jokeDisplayer, ITellJokes jokeTeller)
    {
        if (jokeDisplayer is null) jokeDisplayer = new DisplayService();
        JokeDisplayer = jokeDisplayer;

        if (jokeTeller is null) jokeTeller = new JokeService();
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