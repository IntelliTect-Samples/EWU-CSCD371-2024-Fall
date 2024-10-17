using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string jsonResponse = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;

            return FormatJoke(jsonResponse);
        }

        public static string FormatJoke(string? jsonJoke)
        {
            ArgumentNullException.ThrowIfNull(jsonJoke);

            JsonNode? jokeNode = JsonNode.Parse(jsonJoke);

            return ExtractJoke(jokeNode);
        }

        public static string ExtractJoke(JsonNode? jokeNode)
        {
            if (jokeNode == null || jokeNode["joke"] == null)
            {
                return "No joke found!";
            }

            return jokeNode["joke"]!.ToString(); 
        }
    }
}
