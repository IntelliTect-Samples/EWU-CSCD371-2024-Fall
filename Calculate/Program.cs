using Calculate.Core;
using ConsoleUtilities;

namespace Calculate;

public class Program : ProgramBase
{
    public static void Main()
    {
        Program program = new();
        Calculator calculator = new();

        string GetInput()
        {
            Console.WriteLine("Enter a calculation you want to perform: ");
            return program.ReadLine();
        }

        double PerformCalculation(string input)
        {
            calculator.TryCalculate(input, out double result);
            return result;
        }

        void DisplayResult(double result)
        {
            program.WriteLine($"Result: {result}");
        }

        string input = GetInput();
        double result = PerformCalculation(input);
        DisplayResult(result);
    }
}