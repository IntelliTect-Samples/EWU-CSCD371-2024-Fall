namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public Program() { }
    public static void Main(string[] args)
    {
        Calculator calculator = new();
        Program program = new();
        program.WriteLine("Enter an expression to calculate:");
        string expression = program.ReadLine() ?? "";
        if (calculator.TryCalculate(expression, out double result))
        {
            program.WriteLine($"Result: {result}");
        }
        else
        {
            program.WriteLine("Invalid expression");
        }
    }
}