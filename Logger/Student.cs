namespace Logger;

    public record class Student : Person
    {
        public Student(string FirstName, string MiddleName, string LastName,string ssn, string email, string dateOfBirth, string schoolYear, string major) 
        : base(FirstName, MiddleName, LastName, ssn, email, dateOfBirth)
        {
            SchoolYear = schoolYear;
            Major = major;
        }
        public string SchoolYear { get; set;}
        public string Major { get; set; }

 
    }
