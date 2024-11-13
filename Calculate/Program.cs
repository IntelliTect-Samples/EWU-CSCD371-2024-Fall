
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

    public Program(Action<string> writeLine, Func<string> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;

        calculator = new Calculator();
    }

    public static void Main()
    {
        Program program = new();
        string? userInput;
        do
        {
            userInput = Console.ReadLine();
            if (userInput is null)
            {
                continue;
            }
            if (program.calculator.TryCalculate(userInput, out int outputFromTry))
            {
                program.WriteLine("" + outputFromTry);

            }
            else
            {
                program.WriteLine("Invalid input string. Ensure format: 'int validOperator int'");
            }
        } while (userInput is not "EXIT");
    }
}
