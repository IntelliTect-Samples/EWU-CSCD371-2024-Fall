namespace Logger;

public class LogFactory
{
    private string _filepath = string.Empty;

    public string testFilePath = string.Empty;

    public void ConfigureFileLogger(string filePath)
    {
        _filepath = filePath;
        testFilePath = filePath;
    }
    public BaseLogger? CreateLogger(string className)
    {
        return null;
    }
}