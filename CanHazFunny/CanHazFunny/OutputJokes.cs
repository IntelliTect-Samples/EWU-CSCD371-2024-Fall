using System;


namespace CanHazFunny;

    public class OutputJokes : IOutputJokes
    {
        public void Output(string joke)
        {
            Console.WriteLine();
            Console.WriteLine(joke);
        }
    }

