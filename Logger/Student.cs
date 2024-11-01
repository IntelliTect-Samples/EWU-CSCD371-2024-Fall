using System.Globalization;

namespace Logger;

public record class Student : Person
{
    public Student(int  studentId, string firstName, string? middleName, string lastName)
        : base(firstName, middleName, lastName)
    {
        StudentId = studentId;
    }

    // We used explicit implementation for the Name property becuase we need to be able to take Name and parse
    // it into the StudentId and PersonName properties. We also need to be able to calculate the Name property from the
    // StudentId and PersonName properties.
    override public string Name
    {
        get
        {
            return $"{StudentId}: {PersonName}";
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
}
