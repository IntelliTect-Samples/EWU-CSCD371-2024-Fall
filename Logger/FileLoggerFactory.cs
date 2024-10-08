using System;

namespace Logger;

public class FileLoggerFactory : LoggerFactory
    
{

    public void ConfigureFileLogger(string? path)
    {
       this.FilePath = path;
    }

    public override FileLogger? CreateLogger()
    {
                if (this.FilePath is null) return null;
                FileLogger fileLogger = new FileLogger(this.FilePath){ClassName = nameof(FileLoggerFactory) };
                return fileLogger;
        
    }
}
