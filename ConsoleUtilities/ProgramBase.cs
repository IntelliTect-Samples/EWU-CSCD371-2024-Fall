namespace ConsoleUtilities;

public class ProgramBase
{
    public virtual Action<string> WriteLine { get; init; } = Console.WriteLine;
    public virtual Func<string?> ReadLine { get; init; } = Console.ReadLine;

}
