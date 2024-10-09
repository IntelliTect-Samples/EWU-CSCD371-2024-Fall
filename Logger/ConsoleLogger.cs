using System;
using System.Runtime.CompilerServices;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Logger;

public class ConsoleLogger : BaseLogger
{


    public override void Log(LogLevel logLevel, string message)
    {
        Console.WriteLine(CreateOutputString(logLevel, message, DateTime.Now, ClassName));
    }


    public static string CreateOutputString(LogLevel logLevel, string message, DateTime dateTime, string? caller)
    {
        string baseString = $"{dateTime} {caller} {logLevel}: {message}";
        return baseString;
    }
}
