using ConsoleUtilities;
using System;
using System.Globalization;

namespace Calculate;

public class Program : ProgramBase
{
    private Calculator? calculator;

    public Program() : base()
    {
        calculator = new Calculator();
    }

    public Program(Action<string> writeLine, Func<string?> readLine) : base(writeLine, readLine)
    {

    }

    public static void Run()
    {
        Console.WriteLine("Enter a calculation (e.g., '3 + 4' or '10 * 2') or 'exit' to quit:");
        while (true)
        {
            string? input = Console.ReadLine();

            if (input?.ToLower(CultureInfo.InvariantCulture) == "exit")
            {
                Console.WriteLine("Exiting program.");
                break;
            }

            if (input != null && Calculator.TryCalculate(input, out int result))
            {
                Console.WriteLine($"Result: {result}");
            }
            else
            {
                Console.WriteLine("Invalid calculation. Please follow the format: 'operand1 operator operand2'");
            }
        }
    }
}
