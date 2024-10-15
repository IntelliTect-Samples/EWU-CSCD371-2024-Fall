using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class Jester
{
    private IJokeOutput? _jokeOutput;
    private IJokeService? _jokeService;
    
    private IJokeOutput JokeOutput { 
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _jokeOutput = value;
        }
        get
        {
            return _jokeOutput!;
        }
    }

    private IJokeService JokeService
    {
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _jokeService = value;
        }
        get
        {
            return _jokeService!;
        }
    }


    public Jester(IJokeOutput jokeOutput, IJokeService jokeService)
    {
        //TODO: Null checks
        JokeOutput = jokeOutput;
        JokeService = jokeService;
    }

    public void TellJoke()
    {
        //TODO: Filter out Chuck Norris jokes
        string joke = JokeService.GetJoke();
        while (joke.ToLower().Contains("chuck norris") || joke.ToLower().Contains("chuck") || joke.ToLower().Contains("norris"))
        {
            joke = JokeService.GetJoke();
        }

        JokeOutput.WriteJoke(joke);
    }
}
