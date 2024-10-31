namespace Logger
{
    public record class FullName()
    {
        /*
            Fullname is a record class reference type that represents a person's name. this is because a person's name is mutable.
            The class has three properties: FirstName, MiddleName, and LastName. FirstName and LastName are required properties.
            MiddleName is an optional property that is set to a space character by default.
            The class overrides the ToString method to return the full name of the person.
        */
        private string? _firstName;
        private string? _lastName;

        public string FirstName
        {
            get => _firstName!;
            set
            {
                _firstName = value ?? throw new ArgumentNullException(nameof(FirstName), "First name cannot be null.");
            }
        }

        public string? MiddleName { get; set; } = " ";

        public string LastName
        {
            get => _lastName!;
            set
            {
                _lastName = value ?? throw new ArgumentNullException(nameof(LastName), "Last name cannot be null.");
            }
        }

        public override string ToString() => $"{FirstName}, {MiddleName?.Trim()}, {LastName}";
    }
}