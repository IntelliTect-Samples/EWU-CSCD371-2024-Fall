namespace Logger;

public record class Employee(FullName FullName, string Position, string Department) : Person(FullName)
{
    public string Position { get; init; } = Position; 
    public string Department { get; init; } = Department; 

    // The Name property is implemented in the Person class, no need to override it here.
    // The Id property is inherited from BaseEntity, no need to define it.
}

