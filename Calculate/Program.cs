namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; }
    public Func<string> ReadLine { get; init; }

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
    }

    public static void Run()
    {
        Console.WriteLine("Enter a calculation (e.g., '3 + 4' or '10 * 2') or 'exit' to quit:");
        while (true)
        {
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit")
            {
                Console.WriteLine("Exiting program.");
                break;
            }

            if (Calculator.TryCalculate(input, out int result))
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