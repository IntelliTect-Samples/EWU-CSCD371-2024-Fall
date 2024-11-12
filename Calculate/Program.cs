using System.Globalization;

namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; }
    public Func<string?> ReadLine { get; init; }

    private Calculator? calculator;

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
}
