using Calculate.Core;
using ConsoleUtilities;

namespace Calculate;

public class Program : ProgramBase
{
    public static void Main()
    {
        Program program = new();
        Console.WriteLine("Enter a calculation you want to perform: ");
        string input = program.ReadLine();
        Calculator calculator = new();
        calculator.TryCalculate(input, out double result);
        program.WriteLine($"Result: {result}");
    }
}