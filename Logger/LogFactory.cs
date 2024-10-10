namespace Logger;

using System.IO;
using System.Reflection;

public class LogFactory
{
    private string? FilePath { get; set; }

    public void ConfigureFileLogger(string? filePath)
    {
        string? assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        if (filePath == null)
        {
            return;
        }
        
        if (assemblyPath != null)
        {
            FilePath = Path.Combine(assemblyPath, filePath);
        }
        else
        {
            FilePath = filePath;
        }
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