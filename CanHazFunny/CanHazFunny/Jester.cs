
using System;

namespace CanHazFunny.Tests;

public class Jester
{
    private readonly IDisplayJokes _displayService;
    private readonly IJokeService _jokeService;

    public Jester(IDisplayJokes dispalyService, IJokeService jokeService)
    {
        _displayService = dispalyService ?? throw new ArgumentNullException(nameof(dispalyService));
        _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    }

    public void TellJoke()
    {
        var joke = _jokeService.GetJoke();
        if (!joke.Contains("Chuck Norris"))
        {
            _displayService.DisplayJoke(joke);
        }
    }
}