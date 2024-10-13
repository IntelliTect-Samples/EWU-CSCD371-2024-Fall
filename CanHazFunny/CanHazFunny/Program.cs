namespace CanHazFunny;

using CanHazFunny;
using System;

class Program
{
    static void Main(string[] args)
    {
        Boolean keepTellingJokes = true;
        Jester jester = new();


        while (keepTellingJokes == true)
        {
           
            System.Console.WriteLine("Would you like to hear a joke? (Y/N)");
            string response = Console.ReadLine().ToUpper();
            if (response == "N")
            {
                keepTellingJokes = false;
            }
            else if (response == "Y")
            {
                jester.TellJoke();
            }
            else
            {
                System.Console.WriteLine("Invalid input. Please enter Y or N.");
            }
        
        
        }


        System.Console.WriteLine("Goodbye! Its been fun!");

        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
    }
}
