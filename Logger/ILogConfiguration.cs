namespace Logger;
// TODO: Change ILoggerConfiguration and its implementaions so that variable Logsource and method signature for Log(..) from implied to explicitly say public abstract
/// <summary>
/// Contains:<br/>
/// <seealso cref="LogSource"/>
/// </summary>
public interface ILoggerConfiguration
{
    /// <summary>
    /// Calling class name
    /// </summary>
    string LogSource { get; }
    
}