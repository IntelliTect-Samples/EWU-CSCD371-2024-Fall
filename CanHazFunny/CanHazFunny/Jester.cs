using CanHazFunny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;
public class Jester
{
    public IJokeService JokeService { get; }
    public IDisplayJokes DisplayJokes { get; }
    public Jester(IJokeService jokeService, IDisplayJokes displayJokes)
    {

        JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        DisplayJokes = displayJokes ?? throw new ArgumentNullException(nameof(displayJokes));

    }
}
