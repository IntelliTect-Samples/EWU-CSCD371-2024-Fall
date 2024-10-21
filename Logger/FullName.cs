
namespace Logger;




/// <summary>
/// We chose to make the FullName Record a Reference Type (a class over a struct), because names can change
/// and we want programs that contain that record to update. If we did a struct, it would copy but not update existing references.<br/><br/>
///
/// This class is mutable as it has setters that allow the name to change <br/>
/// 
/// </summary>
public record class FullName
{
    private string? _first;
    private string? _middle;
    private string? _last;

    /// <summary>
    /// First is init only, and is never null.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    
    public required string First 
    { 
        get => _first!;
        set{
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value),$"Tried to set a null or empty value for {nameof(First)}");
            _first = value;
        } 
    }

    public required string Last
    {
        get => _last!;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value), $"Tried to set a null or empty value for {nameof(Last)}");
            _last = value;
        }
    }

    public string? Middle 
    {
        get { return _middle; }
        set
        {
            _middle = value;
        }
    }

    public override string ToString()
    {
        if (Middle is null) return First + " " + Last;
        return First + " " + Middle + " " + Last;
    }
}

