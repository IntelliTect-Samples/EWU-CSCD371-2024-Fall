using System;

namespace Logger;

public abstract class LogFactory
    
{

    public string? FilePath { get; set; }

    public abstract BaseLogger? CreateLogger();
    //{
    //    if (className is null) return null;
    //    switch (className.ToLower())
    //    {
    //        case "":
    //            return null;
               
    //        case "testlogger":
    //            return new TestLogger() { ClassName = "TestLogger"};

    //        case "filelogger":
    //            if (this.FilePath is null) return null;
    //            FileLogger fileLogger = new FileLogger(this.FilePath){ClassName = "FileLogger" };
    //            return fileLogger;

    //        case "consolelogger":
    //            ConsoleLogger consoleLogger = new ConsoleLogger { ClassName = "ConsoleLogger" };
    //            return consoleLogger;

    //        default:
    //            return null;
    //    }
    
}
