using Interfaces;
using System;

namespace CanHazFunny;

    public class Jester
    {
        //Private field to hold the IJokeService - do these need to be readonly or Get/Set?
        private IJokeService _jokeService;
        private IJokeOutput _jokeOutput;


        //Contructor needs to take in IJokeService, not JokeService. Allows flexibility in how joke is provided.
        public Jester(IJokeService jokeService, IJokeOutput jokeOutput)
        {
            _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            _jokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
        }

        //Establish TellJoke for Jester, which will call GetJoke. Need to add assessing for Chuck Norris.
        public string TellJoke()
        {
            string joke = _jokeService.GetJoke();
            // No if statement beacuse it can create a recursive call without an exit. Use a while statement.
            while (joke.Contains("chuck norris", StringComparison.InvariantCultureIgnoreCase))
            {
                joke = _jokeService.GetJoke();
            }
            _jokeOutput.OutputJoke(joke);  //When this is active, test times output.
            return joke;
        }
    }

