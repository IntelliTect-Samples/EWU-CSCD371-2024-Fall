namespace Logger;

public interface ILoggerConfiguration
{
    string LogSource { get; }
    
}

/* 
Setup :
 Member - Type - Reason 

 LogSource - explicit - "LogSource is only called by the backend frontend should not be sourcing their own logs."


 
 */