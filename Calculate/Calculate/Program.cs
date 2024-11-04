//Write a test that sets these properties at construction time and then invokes the properties and verifies the
//expected behavior occurs. ❌✔
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
}
