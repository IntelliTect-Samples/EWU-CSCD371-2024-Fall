
using System.Runtime.InteropServices;
using static CanHazFunny.JokeService;

namespace CanHazFunny

{
    interface Joker
    {
        string TellJoke();
        string TellJokeJson();
    }

    public class Jester : Joker
    {
        JokeService jokeService = new ();
        public string TellJoke()
        {
            System.Console.WriteLine(jokeService.GetJoke());
            return jokeService.GetJoke();
        }

        public string TellJokeJson()
        {
            System.Console.WriteLine(jokeService.GetJokeJson());
            return jokeService.GetJoke();

        }
    }
}