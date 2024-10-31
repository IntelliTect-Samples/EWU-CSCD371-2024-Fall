namespace Logger;

public record Employee : Person
{
    public string EmployeeId { get; init; }

    public Employee(FullName fullName, string employeeId) : base(fullName)
    {
        EmployeeId = employeeId;
    }

    // Implicitly implementing GetId to return the EmployeeId
    // The employee can have a unique id
    protected override string GetId() => EmployeeId;
}
