namespace Calculate;

public class Program
{
    public Program(Action<string> writeLine, Func<string?> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    public Program() : this(Console.WriteLine, Console.ReadLine)
    {
    }

    public Action<string> WriteLine { get; init; }
    public Func<string?> ReadLine { get; init; }

    public static void Main(string[] args)
    {
        var calculator = new Calculator();
        var program = new Program();

        program.WriteLine("Enter an expression to calculate (Format as '4 + 3'):");
        var input = program.ReadLine();
        if (input != null && calculator.TryCalculate(input, out var result))
        {
            program.WriteLine($"Result: {result}");
        }
        else
        {
            program.WriteLine("Invalid input.");
        }
    }
}
