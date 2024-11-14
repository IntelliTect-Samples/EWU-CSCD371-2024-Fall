using ConsoleUtilities;
namespace Calculate;

public class Program : ProgramBase
{
    public Program() { }
    public static void Main(string[] args)
    {
        Program program = new();
        Calculator<double> calculator = new();
        string input;
        double answer;

        do
        {
            program.WriteLine("Enter the expression to calculate:");
            input = program.ReadLine() ?? string.Empty;
        } while (!calculator.TryCalculate(input, out answer));

        program.WriteLine($"Answer: {answer}");
    }
}
