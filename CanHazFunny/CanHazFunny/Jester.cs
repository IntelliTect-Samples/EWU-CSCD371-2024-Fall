namespace CanHazFunny;
public interface IJoker
    {
        void TellJoke();
        void TellJokeJson();
    }
    public class Jester : IJoker 
    {
        private JokeService jokeService = new ();
        public void TellJoke()
    {
        string response = jokeService.GetJoke();
        bool isntChuckNorris = response.Contains("Norris")|| response.Contains("Chuck");

        if (!isntChuckNorris)
        {
            System.Console.WriteLine(response);
        }
        else
        {
            TellJoke();
        }
    }
        public void TellJokeJson()
        {

        string jsonResponse = jokeService.GetJoke();
        bool isntChuckNorris = jsonResponse.Contains("Norris")||jsonResponse.Contains("Chuck");
        if (!isntChuckNorris)
        {
            System.Console.WriteLine(jsonResponse);
        }
        else
        {
            TellJokeJson();
        }
        }
    }
