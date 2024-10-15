using System;
namespace CanHazFunny
{
    public class Jester
    {
        private IJokeService _jokeService; // hold instance of joke service
        private IOutputService _outputService; // hold instance of output service

        // Constructor
        public Jester(IOutputService outputService, IJokeService jokeService)
        {
            // Assign dependencies to private fields
            _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
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
            _outputService.WriteJoke(joke);
        }
    }
}

