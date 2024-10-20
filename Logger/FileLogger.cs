namespace Logger;
/// <summary>
/// Contains:<br/>
/// <seealso cref="FilePath"/><br/>
/// <seealso cref="FileLogger(string,string)"/><br/>
/// <seealso cref="FileLogger(FileLoggerConfiguration)"/><br/>
/// <seealso cref=""/><br/>
/// </summary>
///<remarks>
///
/// This class uses
/// <seealso cref="ILogger"/> 
/// and
/// <seealso cref="BaseLogger"/>
/// </remarks>
public class FileLogger : BaseLogger, ILogger
{
    private FileInfo File { get; }

    public string FilePath { get => File.FullName; }
    /// <summary>
    /// Sets logsource in base class and saves filePath to FilePath
    /// </summary>

    /// <exception cref="NullReferenceException"></exception>
    /// <remarks>
    /// NullReferenceException Thrown if either <paramref name="logSource"/> or <paramref name="filePath"/> is null.
    /// </remarks>
    public FileLogger(string logSource, string filePath) : base(logSource) => File = new FileInfo(filePath);
    /// <summary>
    /// Calls other constructor and passes configuration's LogSource and FilePath
    /// </summary>
    public FileLogger(FileLoggerConfiguration configuration) : this(configuration.LogSource, configuration.FilePath) {}

    /// <summary>
    ///Creats a FileLogger from a FIle Logger Configuration.<br/>
    ///Inherited from <seealso cref="ILogger"/>
    /// </summary>
    /// <exception cref="ArgumentException">logggerConfiguration must be a IFileLoggerConfiguration</exception>

    static ILogger ILogger.CreateLogger(in ILoggerConfiguration logggerConfiguration) => 
        logggerConfiguration is FileLoggerConfiguration configuration
            ? CreateLogger(configuration)
            : throw new ArgumentException("Invalid configuration type", nameof(logggerConfiguration));


    public static FileLogger CreateLogger(FileLoggerConfiguration configuration) => new(configuration);
    /// <summary>
    /// Adds date and source to message, and then uses <seealso cref="File.AppendText(string)"/> to log it to path saved in <seealso cref="FilePath"/>
    /// </summary>
    /// <param name="logLevel"></param>
    /// <param name="message"></param>
    public override void Log(LogLevel logLevel, string message)
    {
        using StreamWriter writer = File.AppendText();
        writer.WriteLine($"{ DateTime.Now },{LogSource},{logLevel},{message}");
    }
}
