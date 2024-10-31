namespace Logger;

public record class Employee(FullName FullName, string Position, string Department) : Person(FullName)
{
    public string Position { get; init; } = !string.IsNullOrWhiteSpace(Position)
        ? Position
        : throw new ArgumentException("Position cannot be null or whitespace.", nameof(Position));

    public string Department { get; init; } = !string.IsNullOrWhiteSpace(Department)
        ? Department
        : throw new ArgumentException("Department cannot be null or whitespace.", nameof(Department));

    // The Name property is implemented in the Person class, no need to override it here.
    // The Id property is inherited from BaseEntity, no need to define it.
}

