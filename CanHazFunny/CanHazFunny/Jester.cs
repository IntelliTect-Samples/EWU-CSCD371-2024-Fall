using System;
namespace CanHazFunny
{
    public class Jester
    {
        private IJokeService _jokeService; // hold instance of joke service
        private IOutputService _outputService; // hold instance of output service

        public Jester(IOutputService? outputService, IJokeService? jokeService)
        {
            _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        }

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

