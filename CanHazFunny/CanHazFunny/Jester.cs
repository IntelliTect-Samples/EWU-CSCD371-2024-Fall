
using System;

namespace CanHazFunny.Tests;

public class Jester
{
    private readonly IDisplayJokes _displayService;
    private readonly IJokeService _jokeService;

    public Jester(IDisplayJokes displayService, IJokeService jokeService)
    {
        _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));
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