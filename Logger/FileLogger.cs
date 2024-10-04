namespace Logger;
public class FileLogger : BaseLogger
{
    public override string ClassName { get; set; }

    public override void Log(LogLevel logLevel, string message)
    {
        throw new System.NotImplementedException();
    }
}
