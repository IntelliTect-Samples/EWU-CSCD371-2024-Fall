using System.IO;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System;
namespace Logger;

public class LogFactory
{
    private string? _filePath;

    public string ConfigureFileLogger(string filePath)
    {
        _filePath = filePath;
        return _filePath;
    }

    public BaseLogger? CreateLogger(string className)
    {
        if (_filePath == null)
        {
            return null;
        }
        return new FileLogger(_filePath)
        {
            ClassName = className
        };
    }
}
