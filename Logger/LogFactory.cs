using System.IO;
using System.Runtime.CompilerServices;

namespace Logger;

public class LogFactory
{
    private string _filePath{get; set;}
    public string ConfigureFileLogger(string filePath)
    {
        _filePath = filePath;
    }
    public BaseLogger CreateLogger(string className)
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



/* sudo code
 
  public string DateTime{get; set;}


private void class LogWriter
    {

public string DateTime{get; set;} = DateTime.Now.ToString("ddd, dd MMMM yyyy HH:mm:ss tt");

public string MethodName{get; set;} = xxx;

public string LogLevel = Log();

public string LogMessage = LogLevel.Message();
    Console.WriteLine($"{0} - {1} - {2}" DateTime, MethodName, LogLevel);
    Console.WriteLine(!"{0}" LogMessage);
    }
 
}
 I think we need to uses factory pattern 

public class Logged 
{
 public string DateTime{get; set;};

public string MethodName{get; set;};

public string LogLevel{get; set;};
  
     public Logged()
    {
        DateTime = DateTime.Now.ToString("ddd, dd MMMM yyyy HH:mm:ss tt");

        MethodName = Log;

        LogLevel = Log();

        public string LogMessage = LogLevel.Message();
        
        Console.WriteLine($"{0} - {1} - {2}" DateTime, MethodName, LogLevel);
        
        Console.WriteLine(!"{0}" LogMessage);
    }

    }


 
 
 */



//If the file logger has not be configured in the `LogFactory`, its `CreateLogger` method should return `null`. ❌✔ 
//The `LogFactory` should be updated with a new method `ConfigureFileLogger`. This should take in a file path and store it in a** private member**. It should use this when instantiating a new `FileLogger` in its `CreateLogger` method. ❌✔