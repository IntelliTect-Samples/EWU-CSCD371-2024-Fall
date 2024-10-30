using System.Globalization;

namespace Logger;

public record class Student : BaseEntity
{
    public Student(int  studentId, string firstName, string? middleName, string lastName)
    {
        StudentName = new FullName(firstName, middleName, lastName);
        StudentId = studentId;
    }

    // We used explicit implementation for the Name property becuase we need to be able to take Name and parse
    // it into the StudentId and StudentName properties. We also need to be able to calculate the Name property from the
    // StudentId and StudentName properties.
    override public string Name
    {
        get
        {
            return $"{StudentId}: {StudentName}";
        }
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
            string[] members = value.Trim().Split(':');
            
            try
            {
                StudentId = Int32.Parse(members[0], CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid Student Id");
            }

            string[] studentNames = members[1].Trim().Split(" ");

            if (studentNames.Length == 2)
            {
                StudentName = new FullName(studentNames[0], studentNames[1]);
            }
            else if (studentNames.Length == 3)
            {
                StudentName = new FullName(studentNames[0], studentNames[1], studentNames[2]);
            }
            else
            {
                throw new ArgumentException("Invalid Student Name", members[1]);
            }
        }
    }

    private int? _studentId;
    public int StudentId
    {
        get
        {
            return (int) _studentId!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _studentId = value;
        }
    }

    // TODO: Refactor Common Members between Student and Employee
    private FullName? _studentName;

    public FullName StudentName
    {
        get
        {
            return (FullName)_studentName!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _studentName = value;
        }
    }
}
