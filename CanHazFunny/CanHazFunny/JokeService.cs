using System;
using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        try
        {
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            return joke;
        }
        catch (Exception)
        {
            return "Failed to fetch a joke due to network issues.";
        }
    }
}