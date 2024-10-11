namespace Logger;

public class LogFactory
{

    private string FilePath { get; set; } = "";
    public BaseLogger? CreateLogger(string className)
    {
        if (FilePath == "" || FilePath is null)
        {
            return null;
        }

        FileLogger logger = new FileLogger(FilePath)
        { 
            ClassName = className
        };

        return logger;

    }

    public void ConfigureFileLogger(string filePath)
    {
        FilePath = filePath;
    }
}
