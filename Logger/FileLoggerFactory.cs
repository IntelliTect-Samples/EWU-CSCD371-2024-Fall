using System;

namespace Logger;

public class FileLoggerFactory : LoggerFactory
    
{
    public string? FilePath { get; set; }

    public void ConfigureFileLogger(string? path)
    {
       this.FilePath = path;
    }

    public override FileLogger? CreateLogger(string callingClassName)
    {
                if (this.FilePath is null) return null;
                FileLogger fileLogger = new FileLogger(this.FilePath){ClassName = callingClassName };
                return fileLogger;
        
    }
}
