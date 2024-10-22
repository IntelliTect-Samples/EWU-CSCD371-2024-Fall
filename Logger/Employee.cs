namespace Logger;

public record class Employee : Entity
{
    public FullName EmployeeFullName { get; set; }
    public string EmployeeID { get; init; }
    public string Position { get; set; }
    public Employee(string employeeID, string position, string first, string last, string? middle = null)
    {
        EmployeeFullName = new() { First = first, Last = last, Middle = middle };
        EmployeeID = employeeID ?? throw new ArgumentNullException(nameof(employeeID), $"{nameof(employeeID)} was null.");
        Position = position ?? throw new ArgumentNullException(nameof(position), $"{nameof(position)} was null.");
    }

    protected override string ParseName()
    {
        return EmployeeFullName.ToString();
    }
}