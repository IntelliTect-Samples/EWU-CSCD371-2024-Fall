using System;
using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny;

public class JsonJokeService : ITellJokes
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        return joke;
    }

    public static string? ParseJokeFromJsonString(string jsonString)
    {
        JsonDocument doc = JsonDocument.Parse(jsonString);

        string? response = doc.RootElement.GetProperty("joke").GetString();
        return response;
    }
}