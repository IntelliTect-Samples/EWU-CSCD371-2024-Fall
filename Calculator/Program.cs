using System;
using System.Security.Cryptography.X509Certificates;
using Calculator;
namespace Calculator;
public class Program
{
    public Action<string> WriteLine { get; init; }
    public Func<string?> ReadLine { get; init; }

    public Program()
    {
        WriteLine = Console.WriteLine!;
        ReadLine = Console.ReadLine!;
    }

    public static void Main()
    {
        var program = new Program();
        program.WriteLine("Enter a mathematical expression (e.g., 3 + 4):");
        string? input = program.ReadLine();

        if (input != null && Calculates.TryCalculate(input, out double result))
        {
            program.WriteLine($"Result: {result}");
        }
        else
        {
            program.WriteLine("Invalid expression. Please enter a valid mathematical expression.");
        }
    }
}
