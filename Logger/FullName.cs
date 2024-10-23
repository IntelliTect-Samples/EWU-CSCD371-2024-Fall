using System;

namespace Logger
{
    // So FullName record holds the first, middle(optional), and LastName of a person.
    // I implemented this as a reference type (record class)
    // I did the because a persons full name can be thought of as one object.
    // If FullName were a value type, every time you pass a Student instance around,
    // you would be copying both the Student object and the FullName object

    // The FullName record is immutable by default.
    // So,  FirstName, MiddleName, and LastName can only be set during object creation and cannot be changed afterward.
    // Immutability ensures that once created, the data remains unchanged, and is improtant when people have the same name.

    public record class FullName(string FirstName, string LastName, string? MiddleName = null)
    {
        public string? MiddleName { get; init; } = string.IsNullOrWhiteSpace(MiddleName) ? null : MiddleName;

        public override string ToString()
        {
            if (MiddleName == null)
            {
                return $"{FirstName} {LastName}";
            }
            else
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
        }
    }
}

