namespace Logger;
using System.IO;
using System.Reflection;
public class LogFactory
{
    private string? _filePath;
    public BaseLogger? CreateLogger(string? className)
    {
        if(_filePath == null)
        {
            return null;
        }
        else 
        {
            return new FileLogger(_filePath, className ?? string.Empty);
        }
    }

    public string? ConfigureFileLogger(string? filePath)
    {
        if (filePath == null) {
            return null;
        }
        string? assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (assemblyPath != null)
        {
            return _filePath = Path.Combine(assemblyPath ?? string.Empty, filePath);
        }
        else
        {
           return _filePath = filePath;
        }
    }
}
