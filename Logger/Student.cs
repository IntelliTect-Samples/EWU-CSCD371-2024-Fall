namespace Logger;
    public record Student : Person
    {
        public string SchoolName { get; }
        public int SchoolYear { get; }
        public string Major { get; }
        public string Email { get; }

        public Student(string firstName, string? middleName, string lastName, string email, string schoolName,
            int schoolYear, string major, string ssn, int age, string dateOfBirth)
            : base(new FullName(firstName, middleName, lastName), ssn, age, dateOfBirth)
        {
            Email = !string.IsNullOrWhiteSpace(email)
                ? email
                : throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            SchoolName = !string.IsNullOrWhiteSpace(schoolName)
                ? schoolName
                : throw new ArgumentException("School name cannot be null or empty.", nameof(schoolName));

            Major = !string.IsNullOrWhiteSpace(major)
                ? major
                : throw new ArgumentException("Major cannot be null or empty.", nameof(major));

            SchoolYear = schoolYear >= 0
                ? schoolYear
                : throw new ArgumentException("School year cannot be negative.", nameof(schoolYear));
        }
    }
