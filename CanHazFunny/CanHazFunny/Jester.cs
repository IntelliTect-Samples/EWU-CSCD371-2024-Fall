using System;

namespace CanHazFunny;

public class Jester
{
    private IJokeService _jokeService;
    private IOutputService _outputService;

    public Jester(IOutputService outputService, IJokeService jokeService)
    {
        _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    }

    public void TellJoke()
    {
        string joke;

        do
        {
            joke = _jokeService.GetJoke();


            if (joke == null) throw new ArgumentNullException(nameof(joke));
        }
        while (joke.Contains("Chuck Norris"));

        _outputService.WriteJoke(joke);
     }
}
