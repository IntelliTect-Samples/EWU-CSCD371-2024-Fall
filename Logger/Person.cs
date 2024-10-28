using System.Globalization;

namespace Logger;

    public record Person(FullName PersonsName, string Ssn, int Age, string DateOfBirth) : EntityBase
    {
        public FullName PersonsName { get; } = PersonsName ?? throw new ArgumentNullException(nameof(PersonsName));

        public string Ssn { get; } = !string.IsNullOrWhiteSpace(Ssn)
            ? Ssn
            : throw new ArgumentException("SSN cannot be null or empty.", nameof(Ssn).ToLowerInvariant());

        // Ensure DateOfBirth is in "MM-DD-YYYY" format and is a valid date
        public string DateOfBirth { get; } = IsValidDateOfBirth(DateOfBirth)
            ? DateOfBirth
            : throw new ArgumentException("Date of Birth must be a valid date in MM-DD-YYYY format.", nameof(DateOfBirth));

        public override string Name => string.IsNullOrWhiteSpace(PersonsName.MiddleName)
            ? $"{PersonsName.FirstName} {PersonsName.LastName}"
            : $"{PersonsName.FirstName} {PersonsName.MiddleName} {PersonsName.LastName}";

        // Validates if the provided DateOfBirth string matches "MM-DD-YYYY" format
        private static bool IsValidDateOfBirth(string dateOfBirth)
        {
            return DateTime.TryParseExact(dateOfBirth, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
