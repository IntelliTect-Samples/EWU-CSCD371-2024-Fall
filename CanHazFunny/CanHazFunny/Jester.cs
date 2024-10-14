
using System.Runtime.InteropServices;
using static CanHazFunny.JokeService;

namespace CanHazFunny

{
    interface Joker
    {
        void TellJoke();
        void TellJokeJson();
    }

    public class Jester : Joker
    {
        JokeService jokeService = new ();
        public void TellJoke()
        {
            System.Console.WriteLine(jokeService.GetJoke());
        }

        public void TellJokeJson()
        {
            System.Console.WriteLine(jokeService.GetJokeJson());
        }
    }
}