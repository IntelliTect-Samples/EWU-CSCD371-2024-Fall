using System.Net.Http;
using System.Text.Json;
using Interfaces;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string jsonResponse = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        using JsonDocument doc = JsonDocument.Parse(jsonResponse);
        string joke = doc.RootElement.GetProperty("joke").GetString() ?? "No joke found";
        return joke;
    }
}
