using Interfaces;
using System;

namespace CanHazFunny
{
    public class Jester : IJokeService, IJokeOutput
    {
        //Private field to hold the IJokeService
        private IJokeService _jokeService;


        //Contructor needs to take in IJokeService, not JokeService. Allows flexibility in how joke is provided.
        public Jester(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        //Establish TellJoke for Jester, which will call GetJoke. Need to add assessing for Chuck Norris.
        public string TellJoke()
        {
            return GetJoke();
        }

        //Added IJokeOutput method to output joke to console.
        public void OutputJoke(string joke)
        {
            Console.WriteLine(joke);
            Console.ReadLine();
        }

        //Added IJokeService method to employ _jokeService to call GetJoke.
        public string GetJoke()
        {
            string joke = _jokeService.GetJoke();
            return joke;
        }
    }
}
