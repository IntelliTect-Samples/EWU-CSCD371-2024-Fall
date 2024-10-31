namespace Logger;

    public record class Student : Person
    {
        /*
            * Constructor for Student
            Student is Explicitly calling the base class constructor, and passing the parameters to the base class constructor
            It extends the Person class, BaseEntity, and IEntity adding SchoolYear and Major.

        */
        public Student(string FirstName, string MiddleName, string LastName,string ssn, string email, string dateOfBirth, string schoolYear, string major) 
        : base(FirstName, MiddleName, LastName, ssn, email, dateOfBirth)
        {
            SchoolYear = schoolYear;
            Major = major;
        }
        public string SchoolYear { get; set;}
        public string Major { get; set; }

 
    }
