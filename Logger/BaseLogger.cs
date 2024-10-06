namespace Logger;

public abstract class BaseLogger
{
    public abstract string _className { get; }

    public abstract void Log(LogLevel logLevel, string message);
}
