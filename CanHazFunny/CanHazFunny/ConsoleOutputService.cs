using System;
using System.Net.Http;

namespace CanHazFunny;

public class ConsoleOutputService : IOutputService
{
    public void WriteJoke(string joke)
    {
        Console.WriteLine(joke);
    }
}

