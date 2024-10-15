
using System.Runtime.InteropServices;
using static CanHazFunny.JokeService;

namespace CanHazFunny;
    public interface IJoker
    {
        void TellJoke();
        void TellJokeJson();
    }
    public class Jester : IJoker
    {
        private JokeService jokeService = new ();
        public void TellJoke()
        {
            string response = jokeService.GetJoke();
            bool isntChuckNorris = response.Contains("Chuck Norris");
        if (isntChuckNorris == false)
        {
            System.Console.WriteLine(response);
        }
        else
        {
            TellJoke();
        }
 

        }
        public void TellJokeJson()
        {

        string jsonResponse = jokeService.GetJoke();
        bool isntChuckNorris = jsonResponse.Contains("Chuck Norris");
        if (isntChuckNorris == false)
        {
            System.Console.WriteLine(jsonResponse);
        }
        else
        {
            TellJokeJson();
        }
        }
    }
