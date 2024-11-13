namespace ConsoleUtilities;

public class ProgramBase
{
    public Action<string> WriteLine { get; init; }

    public Func<string?> ReadLine { get; init; }

    public ProgramBase()
    {
        WriteLine = Console.WriteLine;
        ReadLine = Console.ReadLine;
    }

    public ProgramBase(Action<string> writeLine, Func<string?> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }
}