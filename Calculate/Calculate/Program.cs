public class Program
{
    public Func<string> ReadLine { get; init; }

    public Program()
    {
        ReadLine = Console.ReadLine;
    }

    public static void Main()
    {
    }
}