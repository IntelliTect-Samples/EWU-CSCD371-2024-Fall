using Xunit;

namespace Logger.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Person_CreationWithValidData_SuccessfullyCreatesInstance()
        {
            // Arrange
            var fullName = new FullName("Pedro", "Balmaceda", "Pascal");
            var ssn = "123-45-6789"; // Fake SSN
            var dob = "1975-04-02"; // Pedro Pascal's date of birth
            var age = 48;

            // Act
            var person = new Person(fullName, ssn, age, dob);

            // Assert
            Assert.NotNull(person);
            Assert.Equal(fullName, person.PersonsName);
            Assert.Equal(ssn, person.Ssn);
            Assert.Equal(age, person.Age);
            Assert.Equal(dob, person.DateOfBirth);
        }

        [Fact]
        public void Person_AssignedIdUponCreation_IdIsNotEmpty()
        {
            // Arrange
            var fullName = new FullName("Paul", "William", "Walker");
            var ssn = "987-65-4321"; // Fake SSN
            var person = new Person(fullName, ssn, 40, "1973-09-12");

            // Act 
            var personEntity = (IEntity)person;
            var personId = personEntity.Id;

            // Assert
            Assert.NotEqual(Guid.Empty, personId);
        }

        [Fact]
        public void Person_NameWithMiddleName_ReturnsFullNameIncludingMiddleName()
        {
            // Arrange
            var fullName = new FullName("Ashley", "Suzanne", "Johnson");
            var person = new Person(fullName, "111-22-3333", 40, "1983-08-09");

            // Act
            var result = person.Name;

            // Assert
            Assert.Equal("Ashley Suzanne Johnson", result);
        }

        [Fact]
        public void Person_NameWithoutMiddleName_ReturnsFullNameWithoutMiddleName()
        {
            // Arrange
            var fullName = new FullName("Emilia", null, "Clarke");
            var person = new Person(fullName, "444-55-6666", 37, "1986-10-23");

            // Act
            var result = person.Name;

            // Assert
            Assert.Equal("Emilia Clarke", result);
        }

        [Fact]
        public void Person_ThrowsArgumentException_WhenSsnIsNullOrEmpty()
        {
            // Arrange
            var fullName = new FullName("Pedro", "Balmaceda", "Pascal");

            // Act & Assert
            var exceptionEmptySsn = Assert.Throws<ArgumentException>(() => new Person(fullName, string.Empty, 48, "1975-04-02"));
            Assert.Equal("SSN cannot be null or empty. (Parameter 'ssn')", exceptionEmptySsn.Message);
            
        }

        [Fact]
        public void Person_ThrowsArgumentNullException_WhenFullNameIsNull()
        {
            // Arrange
            FullName? fullName = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Person(fullName!, "123-45-6789", 48, "1975-04-02"));
            Assert.Equal("Value cannot be null. (Parameter 'PersonsName')", exception.Message);
        }

        [Fact]
        public void Person_ThrowsArgumentException_WhenDateOfBirthIsNullOrEmpty()
        {
            // Arrange
            var fullName = new FullName("Ashley", "Suzanne", "Johnson");

            // Act & Assert
            var exceptionEmptyDob = Assert.Throws<ArgumentException>(() => new Person(fullName, "111-22-3333", 40, string.Empty));
            Assert.Equal("Date of Birth cannot be null or empty. (Parameter 'DateOfBirth')", exceptionEmptyDob.Message);
            
        }
    }
}
