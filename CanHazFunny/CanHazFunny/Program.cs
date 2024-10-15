namespace CanHazFunny;

using CanHazFunny;
using System;
using System.Globalization;

public class Program
{
    private static string currentFormat = "Http";
    static public void Main(string[] args)
    {
        Boolean keepTellingJokes = true;
        Boolean wantJson = false;
        Jester jester = new();

            while (keepTellingJokes == true)
            {
                System.Console.WriteLine("Would you like to hear a joke? (Y/N) or Change formats (F)  Current format:"+currentFormat);
                string response = (Console.ReadLine()?? "N").ToUpper(CultureInfo.InvariantCulture);
                if (response == "N")
                {
                    keepTellingJokes = false;
                }
                else if (response == "Y")
                {
                    if (wantJson == true)
                    {
                    System.Console.WriteLine(System.Environment.NewLine);
                    jester.TellJokeJson();
                    System.Console.WriteLine(System.Environment.NewLine);
                }
                    else
                    {
                    System.Console.WriteLine(System.Environment.NewLine);
                    jester.TellJoke();
                }
                }
            else if (response == "F")
            {
                if (currentFormat == "Http")
                {
                    currentFormat = "Json";
                    wantJson = true;
                    System.Console.WriteLine("Format changed to: " + currentFormat + System.Environment.NewLine);
                }
                else
                {
                    currentFormat = "Http";
                    wantJson = false;
                    System.Console.WriteLine("Format changed to: " + currentFormat + System.Environment.NewLine);
                }
            }
            else
                {
                    System.Console.WriteLine("Invalid input. Please enter Y or N.");
                }
            }    
        System.Console.WriteLine(System.Environment.NewLine+"Goodbye! Its been fun!");
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
    }
}
