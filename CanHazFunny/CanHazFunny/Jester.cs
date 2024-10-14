using System;
namespace CanHazFunny
{
    public class Jester
    {
        private IJokeService _jokeService; // hold instance of joke service
        private IOutput _output; // hold instance of output service

        // Constructor
        public Jester(IJokeService jokeService, IOutput output)
        {
            // Assign dependencies to private fields
            _jokeService = jokeService;
            _output = output;
        }


        // Retrieves a joke from joke service and will display it using
        // output service. Uses while loop to filter out jokes containing
        // Chuck Norris.
        public void TellJoke()
        {
            string joke = _jokeService.GetJoke();

            while (joke.Contains("Chuck Norris"))
            {
                joke = _jokeService.GetJoke();
            }
            _output.WriteJoke(joke);
        }
    }
}

