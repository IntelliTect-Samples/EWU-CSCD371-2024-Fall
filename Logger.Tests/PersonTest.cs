using Xunit;

namespace Logger.Tests
{
    public class PersonTests
    {
        public record class TestPerson : Person
            {
                public TestPerson(string firstName, string middleName, string lastName, string ssn, string email, string dateOfBirth)
                    : base(firstName, middleName, lastName, ssn, email, dateOfBirth)
                {
                }
            }

        [Fact]
        public void CreatePerson_ValidParameters_ReturnsPersonObject()
        {
            // Arrange
            var fullName = new FullName
            {
                FirstName = "John",
                MiddleName = "Doe",
                LastName = "Smith"
            };
            string ssn = "123-45-6789";
            string email = "john.smith@example.com";
            string dateOfBirth = "1990-01-01";

            // Act

            var person = new TestPerson(fullName.FirstName, fullName.MiddleName, fullName.LastName, ssn, email, dateOfBirth);

            // Assert
            Assert.Equal(fullName.ToString(), person.FullName.ToString());
            Assert.Equal(fullName, person.FullName);
            Assert.Equal(ssn, person.Ssn);
            Assert.Equal(email, person.Email);
            Assert.Equal(dateOfBirth, person.DateOfBirth);
        }

        [Fact]
        public void CreatePerson_NullEmail_ReturnsPersonObjectWithDefaultEmail()
        {
            // Arrange
            var fullName = new FullName
            {
                FirstName = "John",
                MiddleName = "Doe",
                LastName = "Smith"
            };
            string ssn = "123-45-6789";
            string dateOfBirth = "1990-01-01";

            // Act
            var person = new TestPerson(fullName.FirstName, fullName.MiddleName, fullName.LastName, ssn, null!, dateOfBirth);

            // Assert
            Assert.Equal("N/A", person.Email);
        }

        [Fact]
        public void ParseName_ValidFullName_ReturnsFullNameAsString()
        {
            // Arrange
            var fullName = new FullName
            {
                FirstName = "John",
                MiddleName = "Doe",
                LastName = "Smith"
            };
            string ssn = "123-45-6789";
            string email = "john.smith@example.com";
            string dateOfBirth = "1990-01-01";
            var person = new TestPerson(fullName.FirstName, fullName.MiddleName, fullName.LastName, ssn, email, dateOfBirth);

            // Act
            var parsedName = person.ParseName();

            // Assert
            Assert.Equal(fullName.ToString(), parsedName);
        }
    }
}