//Define a Program Class
//Define two init-only setter properties, WriteLine and ReadLine, that contain delegates for writing a line of text
//and reading a line of text respectively ❌✔
//Write a test that sets these properties at construction time and then invokes the properties and verifies the
//expected behavior occurs. ❌✔
//Set the default behavior for the WriteLine and ReadLine properties to invoke System.Console versions of the
//methods and add an empty default constructor. ❌✔

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
