﻿using System.Net.Http;
using System.Net.Http.Json;
using static CanHazFunny.JokeService;

namespace CanHazFunny;

interface JokeServicer
{
    string GetJoke();
    void TellJoke();
    string GetJokeJson();

    void TellJokeJson();
}


public class JokeService : JokeServicer
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
        public string Joke { get; set; }
    }

    public string GetJokeJson()
    {
        JokeResponse jokeResponse = HttpClient.GetFromJsonAsync<JokeResponse>("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        return jokeResponse.Joke;
    }
    public void TellJokeJson()
    {
        System.Console.WriteLine(GetJokeJson());
     
    }

   

   

}
