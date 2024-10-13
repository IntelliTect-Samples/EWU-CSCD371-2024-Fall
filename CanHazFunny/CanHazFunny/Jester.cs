
using System.Runtime.InteropServices;
using static CanHazFunny.JokeService;

namespace CanHazFunny

{
    interface Joker
    {
        void TellJoke();
    }

    class Jester : Joker
    {
       JokeService jokeService = new JokeService();
        public void TellJoke()
        {
            System.Console.WriteLine(jokeService.GetJoke());
        }
    }

}