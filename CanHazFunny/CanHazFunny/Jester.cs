using System;

namespace CanHazFunny
{
    public class Jester
    {

        public IJokeService JokeService { get; }
        public IOutputService OutputService { get; }

        public Jester(IOutputService? outputService, IJokeService? jokeService)
        {
            JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            OutputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        }

        public void TellJoke()
        {
            string joke = JokeService.GetJoke();

            while (joke.Contains("Chuck Norris"))
            {
                joke = JokeService.GetJoke();
            }
            OutputService.WriteJoke(joke);
        }
    }
}


