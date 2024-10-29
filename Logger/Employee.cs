namespace Logger;
public record class Employee : BaseEntity
{
    public FullName EmployeeName { get; set; }
    public string EmployeeRole { get; set; }
    public int EmployeeID { get; set; }
    public string Employer { get; set; }
    public Employee(string employeeName, string employer, string role, int? employeeID)
    {
        EmployeeName = ParseEmployeeName(employeeName);
        Employer = employer ?? throw new ArgumentNullException(nameof(employer), $"{nameof(employer)} was null.");
        EmployeeRole = role ?? throw new ArgumentNullException(nameof(role), $"{nameof(role)} was null.");
        EmployeeID = employeeID ?? throw new ArgumentNullException(nameof(employeeID), $"{nameof(employeeID)} was null.");
    }

    private static FullName ParseEmployeeName(string employeeName)
    {
        if (string.IsNullOrWhiteSpace(employeeName))
        {
            throw new ArgumentNullException(nameof(employeeName), "Author name cannot be null or whitespace.");
        }

        // Split the name by spaces
        var nameParts = employeeName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return nameParts.Length switch
        {
            2 => new FullName(nameParts[0], null, nameParts[1]),               // "First Last"
            3 => new FullName(nameParts[0], nameParts[1], nameParts[2]),       // "First Middle Last"
            _ => throw new ArgumentException("Author name must be in 'First Last' or 'First Middle Last' format.", nameof(employeeName))
        };
    }

    public override string Name
    {
        get => $"{EmployeeName.ToString()}";
        set => throw new InvalidOperationException("The Name property is calculated and cannot be set directly.");
    }
}