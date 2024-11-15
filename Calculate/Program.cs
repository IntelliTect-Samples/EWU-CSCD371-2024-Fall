
using System.Reflection.Metadata.Ecma335;

namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; }
    public Func<string?> ReadLine { get; init; }

    private Calculator calculator;

    public Program()
    {
        WriteLine = Console.WriteLine;
        ReadLine = Console.ReadLine;

        calculator = new Calculator();
    }

    public Program(Action<string> writeLine, Func<string?> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;

        calculator = new Calculator();
    }

    public static void Main()
    {
        Program program = new();
        string? userInput;
        Console.WriteLine("Welcome to ultimate calculator.\nEnsure format: 'int validOperator int'\nType EXIT to close the program.");
        
        do
        {
            userInput = Console.ReadLine();

            if (userInput is null || userInput is "EXIT")
            {
                continue;
            }

            int tryCalculateResult;
            bool tryCalculateSuccess;

            try
            {
                tryCalculateSuccess = program.calculator.TryCalculate(userInput, out tryCalculateResult);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("It's not possible to divide by zero, please try again");
                continue;
            }

            if (tryCalculateSuccess)
            {
                program.WriteLine($"Result: {tryCalculateResult}");
            }
            else
            {
                program.WriteLine("Invalid input string. Ensure format: 'int validOperator int'");
            }

        } while (userInput is not "EXIT");
    }
}
