using System.Collections.Generic;

namespace Logger;
public class TestLogger : BaseLogger
{
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
    }
}