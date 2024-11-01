using System.Globalization;

namespace Logger;

public record class Employee : Person
{

    public Employee(int employeeId, string firstName, string? middleName, string lastName, string jobTitle)
        : base(firstName, middleName, lastName)
    {
        EmployeeId = employeeId;
        EmployeeJobTitle = jobTitle;
    }
    // We used explicit implementation for the Name property becuase we need to be able to take Name and parse
    // it into the EmployeeId, PersonName, and EmployeeJobTitle properties. We also need to be able to
    // calculate the Name property from the EmployeeId, PersonName, and EmployeeJobTitle properties.
    override public string Name
    {
        get
        {
            return $"{EmployeeId}: {PersonName}: {EmployeeJobTitle}";
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
                PersonName = new FullName(studentNames[0], studentNames[1]);
            }
            else if (studentNames.Length == 3)
            {
                PersonName = new FullName(studentNames[0], studentNames[1], studentNames[2]);
            }
            else
            {
                throw new ArgumentException("Invalid Student Name", members[1]);
            }

            EmployeeJobTitle = members[2].Trim();
        }
    }

    public int EmployeeId { get; set; }


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
