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
        if (className is null) return null;
        switch (className.ToLower())
        {
            case "":
                return null;
               
            case "testlogger":
                return new TestLogger() { ClassName = "TestLogger"};
               

            case "filelogger":
                if (this.FilePath is null) return null;
                FileLogger logger =new FileLogger(this.FilePath){ClassName = "FileLogger" };
                return logger;

            default:
                return null;
        }
    }
}
