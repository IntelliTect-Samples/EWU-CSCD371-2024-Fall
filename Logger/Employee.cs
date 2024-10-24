namespace Logger;

    public record Employee : Person
    {
        public string Email { get;}
        public string CompanyName { get; }
        public string Position { get; }

        public Employee(FullName name, string email, string companyName,
            string position, string ssn, int age, string dateOfBirth)
            : base(name, ssn, age, dateOfBirth)
        {
            Email = !string.IsNullOrWhiteSpace(email)
                ? email
                : throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            
            CompanyName = !string.IsNullOrWhiteSpace(companyName)
                ? companyName
                : throw new ArgumentException("Company name cannot be null or empty.", nameof(companyName));
            
            Position = !string.IsNullOrWhiteSpace(position)
                ? position
                : throw new ArgumentException("Position cannot be null or empty.", nameof(position));
        }
    }

