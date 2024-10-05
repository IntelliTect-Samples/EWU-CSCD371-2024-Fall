namespace Logger;

using System.IO;
using System.Reflection;

public class LogFactory
{
    private string? FilePath { get; set; }

    public void ConfigureFileLogger()
    {
        // Use Path.Combine with Assembly.GetExecutingAssembly().Location
        string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        FilePath = Path.Combine(assemblyLocation, "file.txt");
    }
    public BaseLogger? CreateLogger(string className)
    {
        if (string.IsNullOrEmpty(FilePath))
        {
            return null;  // Ensure that null is handled
        }

        return new FileLogger(FilePath)
        {
            ClassName = className
        };
    }
}