namespace Logger;

public record Student(FullName FullName, string Year, string Major) : Person(FullName)
{
    // The Name property is inherited from Person and implemented implicitly.

    public string Year { get; init; } = Year;
    public string Major { get; init; } = Major;  
}
