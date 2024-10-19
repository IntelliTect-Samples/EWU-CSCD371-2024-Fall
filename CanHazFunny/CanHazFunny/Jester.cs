using System;

namespace CanHazFunny;

    public sealed class Jester : IJester
    {
        private IOutputJokes outputJokes;
        private IJokeService jokeService;

        public Jester(IOutputJokes outputJokes, IJokeService jokeService)
        {
            this.outputJokes = outputJokes ?? throw new ArgumentNullException(nameof(outputJokes));
            this.jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        }
        public void TellJoke()
        {
            string joke = jokeService.GetJoke();
            outputJokes.Output(joke);
        }

        public void TellJokeJson()
        {
            string joke = jokeService.GetJokeJson();
            outputJokes.Output(joke);
        }
    }
