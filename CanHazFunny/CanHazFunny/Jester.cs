namespace CanHazFunny;
public interface IJoker
    {
        bool TellJoke();
        bool TellJokeJson();
    }
    public class Jester : IJoker 
    {
        private JokeService jokeService = new ();
        public bool TellJoke()
    {
        string response = jokeService.GetJoke();
        bool isntChuckNorris = response.Contains("Norris") || response.Contains("Chuck");

        if (!isntChuckNorris)
        {
            System.Console.WriteLine(response);
            return true;
        }
        else
        {
           
            return TellJoke();
        }
    }
        public bool TellJokeJson()
        {

        string jsonResponse = jokeService.GetJokeJson();
        bool isntChuckNorris = jsonResponse.Contains("Norris") || jsonResponse.Contains("Chuck");
        if (!isntChuckNorris)
        {
            System.Console.WriteLine(jsonResponse);
            return true;
        }
        else
        {
        
            return TellJokeJson();
           
        }
        }
    }
