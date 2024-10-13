namespace CanHazFunny;
using System;
using Interfaces;

class Program
{
    static void Main(string[] args)
    {
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();

        JokeService jokeServ = new JokeService();
        IJokeService jokeService = jokeServ;
        ConsoleJokeOutput jokeOutput = new ConsoleJokeOutput();
        IJokeOutput jokeOutputLog = jokeOutput;



        Jester newJester = new Jester(jokeService, jokeOutputLog);

        newJester.TellJoke();
    }
}
