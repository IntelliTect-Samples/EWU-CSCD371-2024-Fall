namespace Logger;
public class FileLogger : BaseLogger
{
    // readonly so that it can't be changed after the object is constructed.
    private readonly string _filePath;
    public FileLogger (string filePath)
    {
        _filePath = filePath;
    }
    public override string ClassName { get; set; } = string.Empty;

    public override void Log(LogLevel logLevel, string message)
    {
        throw new System.NotImplementedException();
    }
}