using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class Jester
{
    private readonly IJokeOutput _jokeOutput;
    private readonly IJokeService _jokeService;

    public Jester(IJokeOutput jokeOutput, IJokeService jokeService)
    {
        //TODO: Null checks
        _jokeOutput = jokeOutput;
        _jokeService = jokeService;
    }

    public void TellJoke()
    {
        //TODO: Filter out Chuck Norris jokes
        string joke = _jokeService.GetJoke();
        _jokeOutput.WriteJoke(joke);
    }
}
