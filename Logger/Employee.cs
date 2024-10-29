namespace Logger;

    public record class Employee: Person
    {
        public string Position { get; init; } 
        public string Department { get; init; } 
        public Employee(FullName FullName, string ssn, string email, string dateOfBirth, string position, string department) : base(FullName, ssn, email, dateOfBirth)
        {
            Position = position;
            Department = department;
        }
    }
