using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class Jester
{
    private IJokeService _jokeService;
    private IOutputService _outputService;

    public Jester(IJokeService? jokeService, IOutputService? outputService) 
    { 
    
        _jokeService = jokeService ?? throw new ArgumentNullException (nameof(jokeService));
        _outputService = outputService ?? throw new ArgumentNullException (nameof (outputService));
        
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
