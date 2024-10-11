using System;

namespace Logger;

public class FileLoggerFactory : LoggerFactory
    
{
    public string? FilePath { get; set; }

    public void ConfigureFileLogger(string? path)
    {
       FilePath = path;
    }

    public override FileLogger? CreateLogger(string callingClassName)
    {
                if (FilePath is null) return null;
                FileLogger fileLogger = new(FilePath){ClassName = callingClassName };
                return fileLogger;
    }
}
