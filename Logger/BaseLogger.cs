namespace Logger;

public abstract class BaseLogger
{
    public string? ClassName { get; set; }

    //Simple Constructer for BaseLogger
    public abstract void Log(LogLevel logLevel, string message);
}

