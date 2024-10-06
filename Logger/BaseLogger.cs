namespace Logger;

public abstract class BaseLogger
{
    public string ClassName {
        get;
        set;
    }

    public BaseLogger(string className) {
        ClassName = className;
    }

    public abstract void Log(LogLevel logLevel, string message);
}
