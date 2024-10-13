using System;

namespace CanHazFunny;

internal class ConsoleJoke : IJokeTeller
{
    public void TellJoke(string joke)
    {
        Console.WriteLine(joke);
    }
}
