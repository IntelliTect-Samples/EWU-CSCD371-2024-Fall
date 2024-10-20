namespace Logger;
///<summary>
///Implements:<br/>
///<seealso cref="ILoggerConfiguration"/><br/>
///Contains:<br />
///<seealso cref="LogSource"/><br />
///<seealso cref="FilePath"/><br />
///<seealso cref="FileLoggerConfiguration(string,string)"/>
/// </summary>

public class FileLoggerConfiguration : ILoggerConfiguration
{
    ///<summary>
    ///Throws exception if any passed in values are null. Otherwise assigned them into their respective properties.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public FileLoggerConfiguration(string filePath, string logSource)
    {
        FilePath = string.IsNullOrWhiteSpace(filePath)
                ? throw new ArgumentException($"'{nameof(filePath)}' cannot be null or whitespace.", nameof(filePath))
                : filePath;
        LogSource = string.IsNullOrWhiteSpace(logSource)
                ? throw new ArgumentException($"'{nameof(logSource)}' cannot be null or whitespace.", nameof(logSource))
                : logSource;

    }
    public string FilePath { get;  }

    /// <summary>
    /// <seealso cref="ILoggerConfiguration.LogSource"/>
    /// </summary>
    public string LogSource { get; }
}
