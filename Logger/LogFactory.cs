namespace Logger;

using System.IO;
using System.Reflection;

public class LogFactory
{
    private string? FilePath { get; set; }

    public void ConfigureFileLogger()
    {
        // Use Path.Combine with Assembly.GetExecutingAssembly().Location
        //string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        FilePath = Path.Combine(Assembly.GetExecutingAssembly().Location, "file.txt");
    }

    public BaseLogger? CreateLogger(string className)
    {
        if (string.IsNullOrEmpty(FilePath))
        {
            return null;
        }

        var logger = new FileLogger(FilePath)
        {
            ClassName = className 
        };

        return logger;
    }

}

