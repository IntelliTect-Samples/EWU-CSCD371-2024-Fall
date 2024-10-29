namespace Logger;
public record class Employee : Person
{
    public string EmployeeRole { get; set; }
    public string Employer { get; set; }
    public Employee(string employeeName, string employer, string role, int? employeeID) : base(employeeName, employeeID)
    {
        Employer = employer ?? throw new ArgumentNullException(nameof(employer), $"{nameof(employer)} was null.");
        EmployeeRole = role ?? throw new ArgumentNullException(nameof(role), $"{nameof(role)} was null.");
    }
}