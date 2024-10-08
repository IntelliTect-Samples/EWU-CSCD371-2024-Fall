using System;

namespace Logger;

public class FileLogFactory : LogFactory
    
{

    public void ConfigureFileLogger(string? path)
    {
       this.FilePath = path;
    }

    public override FileLogger? CreateLogger()
    {
                if (this.FilePath is null) return null;
                FileLogger fileLogger = new FileLogger(this.FilePath){ClassName = "FileLogger" };
                return fileLogger;
        
    }
}
