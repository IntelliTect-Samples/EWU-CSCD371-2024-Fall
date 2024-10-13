using System.Net.Http;

namespace CanHazFunny;

interface JokeServicer
{
    string GetJoke();
    void TellJoke();
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
}
