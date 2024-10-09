using System;   

namespace Logger;

public abstract class LoggerFactory
    
{

    

    public abstract BaseLogger? CreateLogger(string callingClassName);
    
}
