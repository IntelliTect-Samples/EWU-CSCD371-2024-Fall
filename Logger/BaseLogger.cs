namespace Logger;

public abstract class BaseLogger
{
    public abstract void Log(LogLevel logLevel, string message);
}

public class  FileLogger : BaseLogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }
    protected override void Log(LogLevel logLevel, string message )
    {
        if (string.IsNullOrEmpty(_filePath))
        {
            throw new ArgumentNullException(nameof())
        }
        using (var fs = new FileStream(_filePath,))
        {
            writer.WriteLine($"{DateTime.Now} FileLogger {logLevel} {message}");
        }
    }
}

