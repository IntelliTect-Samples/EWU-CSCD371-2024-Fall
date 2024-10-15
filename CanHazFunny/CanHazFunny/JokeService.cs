using System;
using System.Net.Http;
using System.Net.Http.Json;
using static CanHazFunny.JokeService;

namespace CanHazFunny;
public interface IJokeServicer
{
    string GetJoke();
    void TellJoke();
    string GetJokeJson();
    void TellJokeJson();
}
public class JokeService : IJokeServicer
{
    private HttpClient HttpClient { get; } = new();  
    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        return joke;
    }
    public void TellJoke()
    {
        System.Console.WriteLine(GetJoke());
    }
    public class JokeResponse
    {
        public string Joke { get; set; } = "Chuck Noris Stinks";
    }
    public string GetJokeJson()
    {
        JokeResponse? jokeResponse = HttpClient.GetFromJsonAsync<JokeResponse>("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        if (jokeResponse == null)
        {
            throw new ArgumentNullException("GetJokeJson isNull");
        }
        return jokeResponse.Joke;
    }
    public void TellJokeJson()
    {
        System.Console.WriteLine(GetJokeJson());
    }
}
