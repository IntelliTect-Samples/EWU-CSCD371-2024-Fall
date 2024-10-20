namespace Logger;
/// <summary>
/// Contains:<br/>
///<seealso cref="FileName"/>
///<seealso cref="CreateLogger(string)"/>
///<seealso cref="ConfigureFileLogger(string)"/>
///<br/>
///Expects ConfigureFileLogger to be run before CreateLogger();
/// </summary>
/// TODO: Rename LogFactory to FileLogFactory, or make an abstract factory pattern to support expansion.
public class LogFactory
{
    public string? FileName { get; set; }

    public BaseLogger? CreateLogger(string className) => 
        FileName is null ? null : new FileLogger(className, FileName);

    public void ConfigureFileLogger(string fileName) => FileName=fileName;
}
