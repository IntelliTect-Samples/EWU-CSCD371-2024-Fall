namespace Logger;
using System.IO;
using System.Reflection;
public class LogFactory
{
    public BaseLogger CreateLogger(string className)
    {

        return null;
    }

    private string? _filePath;
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
