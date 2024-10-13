using System;

namespace CanHazFunny
{
    public class DisplayJokes : IDisplayJokes
    {
        public void OutputJoke(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}