namespace Logger;

public class TraceLogger : BaseLogger
{
    public TraceLogger(string className)
    {
        ClassName = className;
    }

    public void Log(LogLevel logLevel, string message)
    {

    }
}
