
using System.Globalization;

namespace Calculate;
public class Program
{
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;
    public Action<string> WriteLine { get; init; } = Console.WriteLine;

    public Program() { }
    public Program(Func<string?> readline, Action<string> writeLine)
    {


        ReadLine = readline;
        WriteLine = writeLine;
    }
    public void Run()
    {
        string input;
        double output;
        bool status;
        Calculator calculator = new();

        WriteLine("Please type a simple mathematical equation or type exit");
        while (true)
        {
            input = ReadLine() ?? "";

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) || input.Equals("", StringComparison.OrdinalIgnoreCase)) break;
            status = calculator.TryCalculate(input, out output);
            if (status)
            {
                WriteLine(output.ToString(new CultureInfo("en-US")));
            }
            else
            {
                WriteLine("Invalid string. Please follow format of '# operator #'");
            }
        }
    }

    public static void Main()
    {
        Program p = new(Console.ReadLine, Console.WriteLine);
        p.Run();
    }


}