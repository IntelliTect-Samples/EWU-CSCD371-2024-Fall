namespace Logger;
    public record class Student : BaseEntity
    {
    public string SchoolName { get; set; }
    public FullName StudentName { get; set; }
    public int StudentID { get; set; }

    public Student(string studentName, string schoolName, int? studentID)
    {
        SchoolName = schoolName ?? throw new ArgumentNullException(nameof(schoolName), $"{nameof(schoolName)} was null.");
        StudentName = ParseStudentName(studentName);
        StudentID = studentID ?? throw new ArgumentNullException(nameof(studentID), $"{nameof(studentID)} was null.");
    }
    public override string Name
    {
        get => $"{StudentName.ToString()}";

        set => throw new InvalidOperationException("The Name property is calculated and cannot be set directly.");
    }
    private static FullName ParseStudentName(string studentName)
    {
        if (string.IsNullOrWhiteSpace(studentName))
        {
            throw new ArgumentNullException(nameof(studentName), "Author name cannot be null or whitespace.");
        }

        // Split the name by spaces
        var nameParts = studentName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return nameParts.Length switch
        {
            2 => new FullName(nameParts[0], null, nameParts[1]),               // "First Last"
            3 => new FullName(nameParts[0], nameParts[1], nameParts[2]),       // "First Middle Last"
            _ => throw new ArgumentException("Author name must be in 'First Last' or 'First Middle Last' format.", nameof(studentName))
        };
    }

}