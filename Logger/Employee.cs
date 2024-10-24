using System.Globalization;

namespace Logger;
// TODO: Comments on each member explaining implicit or explicit implementation

public record class Employee : BaseEntity
{
    // We used explicit implementation for the Name property becuase we need to be able to take Name and parse
    // it into the EmployeeId, EmployeeFullName, and EmployeeJobTitle properties. We also need to be able to
    // calculate the Name property from the EmployeeId, EmployeeFullName, and EmployeeJobTitle properties.
    override public string Name
    {
        get
        {
            return $"{EmployeeId}: {EmployeeFullName}: {EmployeeJobTitle}";
        }
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
            string[] members = value.Trim().Split(':');
            try
            {
                EmployeeId = Int32.Parse(members[0], CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid Student Id");
            }
            string[] studentNames = members[1].Trim().Split(" ");

            if (studentNames.Length == 2)
            {
                EmployeeFullName = new FullName(studentNames[0], studentNames[1]);
            }
            else if (studentNames.Length == 3)
            {
                EmployeeFullName = new FullName(studentNames[0], studentNames[1], studentNames[2]);
            }
            else
            {
                throw new ArgumentException("Invalid Student Name", members[1]);
            }

            EmployeeJobTitle = members[2].Trim();
        }
    }

    public int EmployeeId { get; set; }

    // TODO: Refactor Common Members between Student and Employee
    public FullName EmployeeFullName { get; set; }

    private string? _employeeJobTitle;
    public string EmployeeJobTitle
    {
        get
        {
            return _employeeJobTitle!;
        }
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            _employeeJobTitle = value;
        }
    }

}
