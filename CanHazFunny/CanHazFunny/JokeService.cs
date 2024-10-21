using System;
using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        //string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;

        string jokeResponse = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        var jokeObject = JsonSerializer.Deserialize<JokeResponse>(jokeResponse);

        if (jokeObject == null || string.IsNullOrEmpty(jokeObject.joke))
        {
            return "Error deserializing json content in the JokeService class."; 
        }

        return jokeObject.joke;
    }
}
