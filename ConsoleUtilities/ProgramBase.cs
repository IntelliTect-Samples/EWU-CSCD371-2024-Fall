namespace ConsoleUtilities;

public abstract class ProgramBase
{
    public Action<string> Writeline { get; init; } = Console.WriteLine;
    public Func<string> Readline { get; init; } = Console.ReadLine!;
    
    protected abstract void Run();

    protected static string FormatInput(string input)
    {
        input = input.Replace("+", " + ")
            .Replace("-", " - ")
            .Replace("*", " * ")
            .Replace("/", " / ");
        
        input = System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " ");
        return input;
    }

}