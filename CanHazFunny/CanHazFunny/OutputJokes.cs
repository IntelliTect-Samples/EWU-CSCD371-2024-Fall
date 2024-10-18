using System;


namespace CanHazFunny;

    public sealed class OutputJokes : IOutputJokes
    {
        public void Output(string joke)
        {
            Console.WriteLine();
            Console.WriteLine(joke);
        }
    }

