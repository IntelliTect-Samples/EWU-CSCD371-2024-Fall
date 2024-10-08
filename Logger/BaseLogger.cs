namespace Logger;

public abstract class BaseLogger
{
    public abstract string ClassName { get; }

    public abstract void Log(LogLevel logLevel, string message);
}
