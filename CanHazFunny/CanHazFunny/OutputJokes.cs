using System;


namespace CanHazFunny
{
    class OutputJokes : IOutputJokes
    {
        public void Output(string joke)
        {
            Console.WriteLine();
            Console.WriteLine(joke);
        }
    }
}
