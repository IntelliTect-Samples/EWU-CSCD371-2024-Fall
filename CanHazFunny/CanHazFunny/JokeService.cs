using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string jsonResponse = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;

        return FormatJoke(jsonResponse);
    }

    public string FormatJoke(string jsonJoke)
    {
        JsonNode? jokeNode = JsonNode.Parse(jsonJoke);

        string? joke = jokeNode?["joke"]?.ToString();

        ArgumentNullException.ThrowIfNullOrEmpty(joke, "Joke returned null or empty");

        return joke;
    }
}

//Testing to see if I can push
