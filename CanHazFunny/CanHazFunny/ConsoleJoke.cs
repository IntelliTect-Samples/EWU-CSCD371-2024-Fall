using System;

namespace CanHazFunny;

public class ConsoleJoke : IJokeTeller
{
    public void TellJoke(string joke)
    {
        Console.WriteLine(joke);
    }
}
