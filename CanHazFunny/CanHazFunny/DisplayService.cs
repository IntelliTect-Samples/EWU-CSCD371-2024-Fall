using System;

namespace CanHazFunny;

public class DisplayService : IDisplayJokes
{
    public void DisplayJoke(string joke)
    {
        Console.WriteLine(joke);
    }
}