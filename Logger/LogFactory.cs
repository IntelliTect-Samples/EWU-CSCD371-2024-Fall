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

//If the file logger has not be configured in the `LogFactory`, its `CreateLogger` method should return `null`. ❌✔ 
//The `LogFactory` should be updated with a new method `ConfigureFileLogger`. This should take in a file path and store it in a** private member**. It should use this when instantiating a new `FileLogger` in its `CreateLogger` method. ❌✔