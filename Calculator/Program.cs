using System;
using Calculator;
namespace Calculator;
public class Program
{
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public Program()
    {
        // Default constructor
    }

    public static void Main()
    {
        WriteLine("Enter a mathematical expression (e.g., 3 + 4):");
        string? input = ReadLine();

        if (input != null && Calculates.TryCalculate(input, out double result))
        {
            WriteLine($"Result: {result}");
        }
        else
        {
            WriteLine("Invalid expression. Please enter a valid mathematical expression.");
        }
    }
}
