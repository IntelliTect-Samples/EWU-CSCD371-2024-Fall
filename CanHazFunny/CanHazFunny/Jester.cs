using CanHazFunny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;
public class Jester
{
    private readonly IJokeService _jokeService;
    private readonly IDisplayJokes _displayJokes;
    public Jester(IJokeService jokeService, IDisplayJokes displayJokes)
    {

        _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        _displayJokes = displayJokes ?? throw new ArgumentNullException(nameof(displayJokes));

    }
}
