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

    public FileLogger? CreateLogger()
    {
        if (string.IsNullOrEmpty(FilePath))
        {
            return null;
        }
        return new FileLogger(FilePath);
    }
}