using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System;
namespace Logger;

public abstract class BaseLogger
{
    public abstract void Log(LogLevel logLevel, string message);

    public string? ClassName { get; set; }
}