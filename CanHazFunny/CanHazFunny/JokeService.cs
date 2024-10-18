using System;
using System.Net.Http;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        return ChuckCheck(joke);
    }

    public string GetJokeJson()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        return ChuckCheckJson(joke);
    }

    private string ChuckCheck(string joke)
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
    private string ChuckCheckJson(string joke)
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
