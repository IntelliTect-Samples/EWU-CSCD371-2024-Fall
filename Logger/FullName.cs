namespace Logger;

// Using 'struct' for FullName enables the use of value types
// When comparing this class with others, its not compared by memory, but instead the contents it contains
// Using 'record' makes this value type immutable. Meaning properties in the class are readonly by default
public record struct FullName
{ 
    private string? first;
    private string? middle;
    private string? last;

    public FullName(string? first, string? middle, string? last)
    {
        First = first;
        Middle = middle;
        Last = last;
    }

    public string? First
    {
        get => first;
        set => first = value ?? "";
    }

    public string? Middle
    {
        get => middle;
        set => middle = value ?? "";
    }

    public string? Last
    {
        get => last;
        set => last = value ?? "";
    }
}
