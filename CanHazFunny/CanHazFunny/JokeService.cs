using System;
using System.Net.Http;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        ArgumentException.ThrowIfNullOrEmpty(joke,"Joke thrown at GetJoke");
        return ChuckCheck(joke);
    }

    public string GetJokeJson()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        ArgumentException.ThrowIfNullOrEmpty(joke, "Joke thrown at GetJokeJson");
        return ChuckCheckJson(joke);
    }

    public string ChuckCheck(string joke)
    {
        if (joke.Contains("Chuck", StringComparison.OrdinalIgnoreCase) || joke.Contains("Norris", StringComparison.OrdinalIgnoreCase))
        {
            return GetJoke();
        }
        else
        {
            return joke;
        }
    }
    public string ChuckCheckJson(string joke)
    {
        if (joke.Contains("Chuck", StringComparison.OrdinalIgnoreCase) || joke.Contains("Norris", StringComparison.OrdinalIgnoreCase))
        {
            return GetJokeJson();
        }
        else
        {
            joke = joke.Replace("{\"joke\": \"", "").Replace("\"}", "");
            return joke;
        }
    }
}
