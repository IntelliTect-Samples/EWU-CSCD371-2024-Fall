namespace CanHazFunny
{
    public class Jester
    {
        private IJokeService jokeService;
        private IOutputService outputService;

        public Jester(ConsoleOutputService outputService, JokeService jokeService)
        {
            this.outputService = outputService;
            this.jokeService = jokeService;
        }

        public void TellJoke()
        {
            string joke;

            do
            {
                joke = jokeService.GetJoke();
            }
            while (joke.Contains("Chuck Norris"));

            outputService.WriteJoke(joke);
        }
    }
}
