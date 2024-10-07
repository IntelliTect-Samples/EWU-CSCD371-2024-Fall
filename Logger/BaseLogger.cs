namespace Logger;

public abstract class BaseLogger
{
    public abstract void Log(LogLevel logLevel, string message);
}

public class  FileLogger : BaseLogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }
    protected override void Log(LogLevel logLevel, string message)
    {
        if (string.IsNullOrEmpty(_filePath))
        {
            throw new ArgumentNullException(nameof(_filePath));
        }
        using (var fs = new StreamWriter(_filePath, true))
        {
            Writer.WriteLine($"{DateTime.Now} {nameof()} {logLevel} {message}");
        }
    }
    

               // sudo code

    /*        public static void CreateFileLog(string validFilePath)
        {
            throw new NotImplementedException();


            /*Appends to Baselogger   
             -The current date/time ❌✔
            -The name of the class that created the logger ❌✔
            - The log level ❌✔
            - The message ❌✔ The format may vary, but an example might look like this "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
            
        }*/
}

