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
    }
}
