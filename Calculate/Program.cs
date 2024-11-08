using System.Globalization;
using ConsoleUtilities;

namespace Calculate;

public class Program : ProgramBase
{
    
    public static void Main(string[] args)
    {
        Program program = new();
        program.Run();
    }


     protected override void Run()
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
            string input2 = Readline().ToLower(CultureInfo.InvariantCulture);
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
}
