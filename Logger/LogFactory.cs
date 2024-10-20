namespace Logger;
/// <summary>
/// Contains:<br/>
///<seealso cref="FilePath"/><br/>
///<seealso cref="CreateLogger(string)"/><br/>
///<seealso cref="ConfigureFileLogger(string)"/><br/>
///<br/>
///Expects ConfigureFileLogger to be run before CreateLogger();
/// </summary>
/// TODO: Rename LogFactory to FileLogFactory, or make an abstract factory pattern to support expansion.
public class LogFactory
{
    public string? FilePath { get; set; }

    public BaseLogger? CreateLogger(string className) => 
        FilePath is null ? null : new FileLogger(className, FilePath);

    public void ConfigureFileLogger(string fileName) => FilePath=fileName;
}
