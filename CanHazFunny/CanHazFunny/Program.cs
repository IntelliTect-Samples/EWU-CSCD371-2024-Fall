﻿namespace CanHazFunny;
using System;

class Program
{
    static void Main(string[] args)
    {
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
        
        JokeService jokeService = new JokeService();
        string getJoke = jokeService.GetJoke();
        Console.WriteLine(getJoke);
        Console.ReadLine();
    }
}
