using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string jsonjoke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        var joke = JsonSerializer.Deserialize<JokeMessage>(jsonjoke);
        if(joke != null && joke.Joke != null)
        {
            return joke.Joke;
        }
        throw new System.Exception("Failed to get joke - also a joke btw");
    }
}
