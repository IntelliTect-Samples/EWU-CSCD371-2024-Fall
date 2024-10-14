using CanHazFunny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;
public class Jester
{
    private IJokeService? _jokeService;
    private IDisplayJokes? _displayJokes;
    public IJokeService JokeService
    {
        get => _jokeService!;
        set => _jokeService = value ?? throw new ArgumentNullException(nameof(value));
    }
    public IDisplayJokes DisplayJokes
    {
        get => _displayJokes!;
        set => _displayJokes = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Jester(IJokeService jokeService, IDisplayJokes displayJokes)
    {
        JokeService = jokeService;
        DisplayJokes = displayJokes;
    }
}
