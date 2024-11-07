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
    }
}