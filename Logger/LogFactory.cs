namespace Logger;

public class LogFactory
{

    private string _filePath;
    public BaseLogger CreateLogger(string className)
    {

        FileLogger logger = new FileLogger(_filePath);

        if (logger != null)
        {
            return logger;
        }
        else
        {
            return null;
        }
    }

    public void ConfigureFileLogger(string filePath)
    {
        _filePath = filePath;
    }
}
