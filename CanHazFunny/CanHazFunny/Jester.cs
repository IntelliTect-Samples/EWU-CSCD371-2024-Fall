using System;
using System.Globalization;

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
            lowercaseJoke = joke.ToLower(CultureInfo.InvariantCulture);
        }
        while (lowercaseJoke.Contains("chuck", StringComparison.OrdinalIgnoreCase) && lowercaseJoke.Contains("norris", StringComparison.OrdinalIgnoreCase));

        OutputService.WriteJoke(joke);
    }
}
