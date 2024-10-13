using Interfaces;
using Syetem;
using System;

namespace CanHazFunny
{
    public class Jester : IJokeService, IJokeOutput
    {
        public string TellJoke()
        {
            JokeService jokeService = new JokeService();
            return jokeService.GetJoke();
        }

        public void OutputJoke(string joke)
        {
            Console.WriteLine(joke);
            Console.ReadLine();
        }
    }
}
