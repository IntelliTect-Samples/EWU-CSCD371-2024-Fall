public class Program
{
    public Func<string> ReadLine { get; init; }
    public Action<string> WriteLine { get; init; }

    public Program()
    {
        ReadLine = Console.ReadLine;
        WriteLine = Console.WriteLine;
    }

    public static void Main()
    {
    }
}