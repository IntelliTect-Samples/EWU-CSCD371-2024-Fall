
using System;

namespace CanHazFunny;

public class Jester
{

    private IJokeService? _jokeService;
    private IJokeTeller? _jokeTeller;
    
    public Jester(IJokeService jokeService, IJokeTeller jokeTeller)
    {
        JokeService = jokeService;
        JokeTeller = jokeTeller;
    }

    public IJokeService JokeService
    {
        get
        {
            return _jokeService!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value, "Value passed in for JokeService is null");
            _jokeService = value;
        }
    }
    public IJokeTeller JokeTeller
    {
        get
        {
            return _jokeTeller!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value, "Value passed in for JokeTeller is null");
            _jokeTeller = value;
        }
    }

    public void TellJoke()
    {
        string joke = JokeService.GetJoke();
        while (joke.Contains("Chuck Norris"))
        {
            joke = JokeService.GetJoke();
        }
        JokeTeller.TellJoke(joke);
    }
}
