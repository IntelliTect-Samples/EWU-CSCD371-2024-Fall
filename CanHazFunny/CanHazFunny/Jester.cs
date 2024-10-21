using System;

namespace CanHazFunny;

public class Jester
{
    public IJokeService JokeService { get; set; }
    public IOutputService OutputService { get; set; }

    public Jester(IOutputService outputService, IJokeService jokeService)
    {
        OutputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    }

    public void TellJoke()
    {
        string joke;
        string lowercaseJoke;

        do
        {
            joke = JokeService.GetJoke();
            lowercaseJoke = joke.ToLower();
        }
        while(lowercaseJoke.Contains("chuck") && lowercaseJoke.Contains("norris"));

        OutputService.WriteJoke(joke);
    }
}
