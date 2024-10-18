using System;

namespace CanHazFunny;

    internal class Jester : IJester
    {
        private OutputJokes outputJokes;
        private JokeService jokeService;

        public Jester(OutputJokes outputJokes, JokeService jokeService)
        {
            this.outputJokes = outputJokes;
            this.jokeService = jokeService;
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
