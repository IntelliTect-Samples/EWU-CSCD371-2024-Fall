using System.Globalization;

namespace Logger;

public record class Student : BaseEntity
{

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
