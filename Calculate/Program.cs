using ConsoleUtilities;
using System;
namespace Calculate;

public class Program : ProgramBase
{
    public Program() { }
    public static void Main(string[] args)
    {
        Program program = new();
        Calculator cal = new();
        string input;
        int? ans;

        do
        {
            program.WriteLine("Enter the expression to calculate:");
            input = program.ReadLine() ?? string.Empty;
        } while (!cal.TryCalculate(input, out ans));
        program.WriteLine($"Answer: {ans}");
    }


}
