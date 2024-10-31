namespace Logger;

public record class Employee : Person
{
    public string Position { get; }
    public string Department { get; }

    public Employee(FullName fullName, string position, string department) : base(fullName)
    {
        if (string.IsNullOrWhiteSpace(position))
        {
            throw new ArgumentNullException(nameof(position), "Position cannot be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(department))
        {
            throw new ArgumentNullException(nameof(department), "Department cannot be null or empty.");
        }

        Position = position;
        Department = department;
    }

    // The Name property is inherited from Person, no need to override it here.
    // The Id property is inherited from BaseEntity, no need to define it.
}

