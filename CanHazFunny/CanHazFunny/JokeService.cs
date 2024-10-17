using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        return joke;
    }

    public string GetJokeJson()
    {
        JokeResponse? jokeResponse = HttpClient.GetFromJsonAsync<JokeResponse>("https://geek-jokes.sameerkumar.website/api?format=json").Result;

        if (jokeResponse is null)
        {
            throw new InvalidOperationException("Joke response is null");
        }

        return jokeResponse.Joke ?? throw new InvalidOperationException("Joke is null");
    }
}

public sealed class JokeResponse
{
    public string? Joke { get; set; }
}
