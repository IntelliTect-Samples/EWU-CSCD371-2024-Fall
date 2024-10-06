using System;

namespace Logger;

public class LogFactory
    
{

    public string FilePath { get; set; }

    public void ConfigureFileLogger(string path)
    {
       this.FilePath = path;
    }

    public BaseLogger CreateLogger(string className)
    {
        return null;
    }
}
