namespace Logger;

public record class Employee : Entity
{

    public FullName EmployeeFullName { get; set; }
    public string ID { get; init; }
    public string Position { get; set; }

    public Employee(string employeeID, string position, string first, string last, string? middle = null)
    {
        EmployeeFullName = new() { First = first, Last = last, Middle = middle };
        ID = employeeID ?? throw new ArgumentNullException(nameof(employeeID), $"{nameof(employeeID)} was null.");
        Position = position ?? throw new ArgumentNullException(nameof(position), $"{nameof(position)} was null.");
    }
    //We implemented this implicitly as we felt that parseName works well on implementations and forcing a cast does not help.
    protected override string ParseName()
    {
        return EmployeeFullName.ToString();
    }
}