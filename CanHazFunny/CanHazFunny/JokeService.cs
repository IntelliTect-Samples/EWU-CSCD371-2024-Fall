using System;
using System.Net.Http;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;

        // Check for null.  Note that mockups wouldn't do this by default since this method's code isn't touched
        _ = joke ?? throw new ArgumentNullException(nameof(joke));

        return joke;
    }
}
