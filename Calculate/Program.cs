using System.Globalization;

namespace Calculate;

public class Program
{
    public Action<string> Writeline { get; init; } = Console.WriteLine;
    public Func<string> Readline { get; init; } = Console.ReadLine!;

    
    // Empty Constructor
    public Program() { }
    
    public static void Main(string[] args)
    {
        Program program = new();
        program.Run();
    }


     public void Run()
    {
        Writeline("Enter a mathematical expression: ");
        string input = Readline();
        input = FormatInput(input);
        bool tryAgain = false;
        Calculator calculator = new();
        
        // Loop to allow the user to try again
        do
        {
            if (calculator.TryCalculate(input, out double result))
            {
                Writeline($"Result: {result}");
            }
            Writeline("Would you like to try again?");
            string input2 = Readline().Readline().ToLower(CultureInfo.InvariantCulture);
            if (input2 == "yes")
            {
                Run();
            }
            else
            {
                Writeline("Goodbye!");
                tryAgain = false;
            }
        } while (tryAgain);
        
    }

    private string FormatInput(string input)
    {
        // Ensure there's exactly one space around the operators
        input = input.Replace("+", " + ")
            .Replace("-", " - ")
            .Replace("*", " * ")
            .Replace("/", " / ");

        // Replace multiple spaces with a single space
        input = System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " ");
    
        // Trim any leading or trailing whitespace
        return input.Trim();
    }
}
