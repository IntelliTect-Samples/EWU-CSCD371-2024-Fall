using Xunit;

#pragma warning disable IDE0090
namespace Logger.Tests;
    public class PersonTests
    {
        [Fact]
        public void Person_CreationWithValidData_SuccessfullyCreatesInstance()
        {
            // Arrange
            var fullName = new FullName("Pedro", "Balmaceda", "Pascal");
            var ssn = "123-45-6789"; // Fake SSN
            var dob = "04-02-1975"; // Pedro Pascal's date of birth in MM-DD-YYYY
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
            var person = new Person(fullName, ssn, 40, "09-12-1973");

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
            var person = new Person(fullName, "111-22-3333", 40, "08-09-1983");

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
            var person = new Person(fullName, "444-55-6666", 37, "10-23-1986");

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
            var exceptionEmptySsn = Assert.Throws<ArgumentException>(() => new Person(fullName, string.Empty, 48, "04-02-1975"));
            Assert.Equal("SSN cannot be null or empty. (Parameter 'ssn')", exceptionEmptySsn.Message);
        }

        [Fact]
        public void Person_ThrowsArgumentNullException_WhenFullNameIsNull()
        {
            // Arrange
            FullName? fullName = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Person(fullName!, "123-45-6789", 48, "04-02-1975"));
            Assert.Equal("Value cannot be null. (Parameter 'PersonsName')", exception.Message);
        }

        [Fact]
        public void Person_ThrowsArgumentException_WhenDateOfBirthIsInvalid()
        {
            // Arrange
            var fullName = new FullName("Ashley", "Suzanne", "Johnson");

            // Act & Assert
            var exceptionInvalidDob = Assert.Throws<ArgumentException>(() => new Person(fullName, "111-22-3333", 40, "1983-08-09"));
            Assert.Equal("Date of Birth must be a valid date in MM-DD-YYYY format. (Parameter 'DateOfBirth')", exceptionInvalidDob.Message);
        }

        [Fact]
        public void Person_ThrowsArgumentException_WhenDateOfBirthIsEmpty()
        {
            // Arrange
            var fullName = new FullName("Ashley", "Suzanne", "Johnson");

            // Act & Assert
            var exceptionEmptyDob = Assert.Throws<ArgumentException>(() => new Person(fullName, "111-22-3333", 40, string.Empty));
            Assert.Equal("Date of Birth must be a valid date in MM-DD-YYYY format. (Parameter 'DateOfBirth')", exceptionEmptyDob.Message);
        }

        [Fact]
        public void Person_Equality_AssertsTrue()
        {
            // Arrange
            FullName person = new FullName("Denzel", "Hayes", "Washington"); 
            string ssn = "123-45-6789"; // Fake SSN
            string dob = "12-28-1954"; // Denzel Washington's date of birth in MM-DD-YYYY
            int age = 68;
            Person person1 = new Person(person, ssn, age, dob);
            Person person2 = person1 with { };
            
            //Act
            bool result = person1.Equals(person2);
            
            //Assert
            Assert.True(result);
            
        }
        
        [Fact]
        public void Person_ReferenceEquality_AssertsFalse()
        {
            // Arrange
            FullName person = new FullName("Denzel", "Hayes", "Washington"); 
            string ssn = "123-45-6789"; // Fake SSN
            string dob = "12-28-1954"; // Denzel Washington's date of birth in MM-DD-YYYY
            int age = 68;
            Person person1 = new Person(person, ssn, age, dob);
            Person person2 = person1 with { };
            
            //Act
            bool result = ReferenceEquals(person1, person2);
            
            //Assert
            Assert.False(result);
        }
    }

