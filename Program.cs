using System;
using Calculate_;

public class Program
{
    public static Action<string> WriteLine = Console.WriteLine;
    public static Func<string?> ReadLine = Console.ReadLine;

    public static void Main()
    {
        WriteLine("Enter a mathematical expression (e.g., 3 + 4):");
        string? input = ReadLine();

        if (input != null && Calculator.TryCalculate(input, out double result))
        {
            WriteLine($"Result: {result}");
        }
        else
        {
            WriteLine("Invalid expression. Please enter a valid mathematical expression.");
        }
    }
}