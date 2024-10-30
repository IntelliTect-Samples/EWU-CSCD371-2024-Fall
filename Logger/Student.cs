namespace Logger;
    public record class Student : Person
    {

    //These properties are implemented implicitly, as they belong to Student and do not require special handling.
    public string SchoolName { get; set; }

    public Student(string studentName, string schoolName, int studentID) : base(studentName, studentID)
    {
        SchoolName = schoolName ?? throw new ArgumentNullException(nameof(schoolName), $"{nameof(schoolName)} was null.");
    }
}