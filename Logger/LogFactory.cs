using System.IO;
using System.Runtime.CompilerServices;

namespace Logger;

public class LogFactory
{
    public BaseLogger CreateLogger(string className)
    {

        return null;
    }

    public string ConfigureFileLogger(string filePath)
    {
        private string privFilePath = filePath;
        
        
        return privFilePath; 
    
    }
}

//If the file logger has not be configured in the `LogFactory`, its `CreateLogger` method should return `null`. ❌✔ 
//The `LogFactory` should be updated with a new method `ConfigureFileLogger`. This should take in a file path and store it in a** private member**. It should use this when instantiating a new `FileLogger` in its `CreateLogger` method. ❌✔