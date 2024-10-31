namespace Logger;

    public record class Employee : Person
    {
        /*
            * Constructor for Employee
            Employee is Explicitly calling the base class constructor
            It extends the Person class, BaseEntity, and IEntity adding Position and Department.
        */
        public Employee(string FirstName, string MiddleName, string LastName, string ssn, string email, string dateOfBirth, string position, string department) 
        : base(FirstName, MiddleName, LastName, ssn, email, dateOfBirth)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }
        public string Position { get; set; } 
        public string Department { get; set; } 
 
    }
