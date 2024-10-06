namespace Logger;
using System.IO;
using System.Reflection;
public class LogFactory
{
    private string? _filePath { get; set; }
    public BaseLogger? CreateLogger(string className)
    {
        if(_filePath == null)
        {
            return null;
        }
        else 
        {
            return new FileLogger(_filePath, className);
        }
    }

    public void ConfigureFileLogger(string filePath)
    {
        if (filePath == null) {
            return;
        }
        string? assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (assemblyPath != null)
        {
            _filePath = Path.Combine(assemblyPath, filePath);
        }
        else
        {
            _filePath = filePath;
        }
    }
}
