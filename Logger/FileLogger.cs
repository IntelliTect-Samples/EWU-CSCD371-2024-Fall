namespace Logger;

public class FileLogger : BaseLogger
{
    public FileLogger(string logSource, string filePath)
    {
        LogSource = logSource;
        FilePath=filePath;
        File = new FileInfo(FilePath);
    }

    public override string LogSource { get; }
    public string FilePath { get; }

    FileInfo File { get; }

    public override void Log(LogLevel logLevel, string message)
    {
        using StreamWriter writer = File.AppendText();
        writer.WriteLine($"{ DateTime.Now },{LogSource},{logLevel},{message}");
    }
}
