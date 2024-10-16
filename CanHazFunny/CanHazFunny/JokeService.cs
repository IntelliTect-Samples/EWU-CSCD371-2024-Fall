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
        
        JsonNode? jokeNode = JsonNode.Parse(jsonResponse);

        string joke = jokeNode?.ToString() ?? "No joke for you!";

        return joke;
    }
}

//Testing to see if I can push
