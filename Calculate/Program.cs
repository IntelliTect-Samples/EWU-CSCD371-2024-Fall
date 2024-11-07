﻿using System.Globalization;

namespace Calculate;

public class Program
{
    public Action<string> Writeline { get; init; } = Console.WriteLine;
    public Func<string> Readline { get; init; } = Console.ReadLine!;

    
    // Empty Constructor
    public Program() { }
    
    public static void Main(string[] args)
    {
        Program program = new();
        program.Run();
    }

    public void Run()
    {
        Writeline("Enter a mathematical expression: ");
        string input = Readline();
        Calculator calculator = new();
        if (calculator.TryCalculate(input, out double result))
        {
            Writeline($"Result: {result}");
        }
        else
        {
            Writeline("Invalid Equation. Here's an Example: 1 + 1");
            Writeline("Would you like to try again?");
            // Changed to CultureInfo.InvariantCulture
            string input2 = Readline().ToLower(CultureInfo.InvariantCulture);
            if (input2 == "yes")
            {
                Run();
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}