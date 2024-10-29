// Purpose: This file contains the Student class which is a subclass of the Person class. It contains the properties Year and Major.
namespace Logger
{
    public record class Student : Person
    {
        public string SchoolYear { get; }
        public string Major { get; }

        public Student( FullName fullName,string Ssn, string Email, string dateOfBirth, string schoolYear, string Major) : base(fullName, Ssn, Email, dateOfBirth)
        {
            this.SchoolYear = schoolYear;
            this.Major = Major;
        }
    }
}