namespace Calculate;

public class Program
{
    private Action<string> _writeLine = Console.WriteLine;
    private Func<string> _readLine = Console.ReadLine!;

    public Action<string> WriteLine
    {
        get => _writeLine;
        init => _writeLine = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(value)} cannot be null.");
    }

    public Func<string> ReadLine
    {
        get => _readLine;
        init => _readLine = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(value)} cannot be null.");
    }

    public static void Main()
    {
    }
}