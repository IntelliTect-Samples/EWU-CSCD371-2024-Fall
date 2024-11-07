using Calculate.Core;
using ConsoleUtilities;

namespace Calculate;

public class Program : ProgramBase
{
    public static void Main()
    {
        Program program = new();
        program.Run();
    }

    public void Run()
    {
        Calculator<double> calculator = new();

        string input = GetInput();
        double result = PerformCalculation(calculator, input);
        DisplayResult(result);
    }

    public string GetInput()
    {
        Console.WriteLine("Enter a calculation you want to perform: ");
        return ReadLine();
    }

    public static double PerformCalculation(Calculator<double> calculator, string input)
    {
        calculator.TryCalculate(input, out double result);
        return result;
    }

    public void DisplayResult(double result)
    {
        WriteLine($"Result: {result}");
    }
}