namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; set; } = Console.WriteLine;
    public Func<string?> ReadLine { get; set; } = Console.ReadLine;
    public static void Main(string[] args)
    {
        Calculator calculator = new();
        Program program = new();
        program.WriteLine("Enter an expression to calculate:");
        string expression = program.ReadLine() ?? "";
        if (calculator.TryCalculate(expression, out int result))
        {
            program.WriteLine($"Result: {result}");
        }
        else
        {
            program.WriteLine("Invalid expression");
        }
    }
}