using System;

namespace CanHazFunny;

    public class Menu
    {
        public static void ShowMenu()
        {
            bool shouldExit = false;

            while (!shouldExit)
            {
                Console.WriteLine("Select the format:");
                Console.WriteLine("1. JSON");
                Console.WriteLine("2. HTTP");
                Console.WriteLine("3. Quit");

                int choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        new Jester(new OutputJokes(), new JokeService()).TellJokeJson();
                        break;
                    case 2:
                        new Jester(new OutputJokes(), new JokeService()).TellJoke();
                        break;
                    case 3:
                        shouldExit = true;
                        break;
                    default:
                        Console.WriteLine(System.Environment.NewLine+"Invalid choice. Please try again."+System.Environment.NewLine);
                        break;
                }
            }
        }

        private static int GetChoice()
        {
            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine() ?? throw new ArgumentException("Console given no input");
            int choice;
            if (int.TryParse(input, out choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
                return GetChoice();
            }
        }
    }

