using Interfaces;
using System;

namespace CanHazFunny
{
    public class Jester
    {
        //Private field to hold the IJokeService - do these need to be readonly or Get/Set?
        private IJokeService _jokeService;
        private IJokeOutput _jokeOutput;


        //Contructor needs to take in IJokeService, not JokeService. Allows flexibility in how joke is provided.
        public Jester(IJokeService jokeService, IJokeOutput jokeOutput)
        {
            _jokeService = jokeService;
            _jokeOutput = jokeOutput;
        }

        //Establish TellJoke for Jester, which will call GetJoke. Need to add assessing for Chuck Norris.
        public string TellJoke()
        {
            string joke = _jokeService.GetJoke();
            _jokeOutput.OutputJoke(joke);
            return joke;
        }

        ////Added IJokeOutput method to output joke to console.
        //public void OutputJoke(string joke)
        //{
        //    _jokeOutput.OutputJoke(string joke);
        //}

        ////Added IJokeService method to employ _jokeService to call GetJoke.
        //public string GetJoke()
        //{
        //    string joke = _jokeService.GetJoke();
        //    return joke;
        //}
    }
}
