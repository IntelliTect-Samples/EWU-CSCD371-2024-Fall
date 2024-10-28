using Xunit;
namespace Logger.Tests;
    public class EmployeeTests
    {
        [Fact]
        public void Employee_CreationWithValidData_SuccessfullyCreatesInstance()
        {
            // Arrange
            var fullName = new FullName("Emily", "Olivia", "Blunt");
            var email = "emily.blunt@company.com";
            var companyName = "Famous Productions";
            var position = "Actor";
            var ssn = "123-45-6789"; // Fake SSN
            var dob = "02-23-1983"; // Emily Blunt's date of birth in MM-DD-YYYY format
            var age = 41;

            // Act
            var employee = new Employee(fullName, email, companyName, position, ssn, age, dob);

            // Assert
            Assert.NotNull(employee);
            Assert.Equal(fullName, employee.PersonsName);
            Assert.Equal(email, employee.Email);
            Assert.Equal(companyName, employee.CompanyName);
            Assert.Equal(position, employee.Position);
            Assert.Equal(ssn, employee.Ssn);
            Assert.Equal(age, employee.Age);
            Assert.Equal(dob, employee.DateOfBirth);
        }

        [Fact]
        public void Employee_AssignedIdUponCreation_IdIsNotEmpty()
        {
            // Arrange
            var fullName = new FullName("Chris", "Robert", "Evans");
            var employee = new Employee(fullName, "chris.evans@company.com", "Marvel Studios", "Actor", "987-65-4321", 42, "06-13-1981");

            // Act
            var employeeEntity = (IEntity)employee;
            var employeeId = employeeEntity.Id;

            // Assert
            Assert.NotEqual(Guid.Empty, employeeId);
        }

        [Fact]
        public void Employee_NameWithMiddleName_ReturnsFullNameIncludingMiddleName()
        {
            // Arrange
            var fullName = new FullName("Chris", "Robert", "Evans");
            var employee = new Employee(fullName, "chris.evans@company.com", "Marvel Studios", "Actor", "987-65-4321", 42, "06-13-1981");

            // Act
            var result = employee.Name;

            // Assert
            Assert.Equal("Chris Robert Evans", result);
        }

        [Fact]
        public void Employee_NameWithoutMiddleName_ReturnsFullNameWithoutMiddleName()
        {
            // Arrange
            var fullName = new FullName("Scarlett", null, "Johansson");
            var employee = new Employee(fullName, "scarlett.johansson@company.com", "Marvel Studios", "Actor", "123-45-6789", 39, "11-22-1984");

            // Act
            var result = employee.Name;

            // Assert
            Assert.Equal("Scarlett Johansson", result);
        }

        [Fact]
        public void Employee_ThrowsArgumentException_WhenEmailIsNullOrEmpty()
        {
            // Arrange
            var fullName = new FullName("Robert", "John", "Downey");

            // Act & Assert
            var exceptionEmptyEmail = Assert.Throws<ArgumentException>(() => new Employee(fullName, string.Empty, "Marvel Studios", "Actor", "111-22-3333", 58, "04-04-1965"));
            Assert.Equal("Email cannot be null or empty. (Parameter 'email')", exceptionEmptyEmail.Message);

            var exceptionNullEmail = Assert.Throws<ArgumentException>(() => new Employee(fullName, null!, "Marvel Studios", "Actor", "111-22-3333", 58, "04-04-1965"));
            Assert.Equal("Email cannot be null or empty. (Parameter 'email')", exceptionNullEmail.Message);
        }

        [Fact]
        public void Employee_ThrowsArgumentException_WhenCompanyNameIsNullOrEmpty()
        {
            // Arrange
            var fullName = new FullName("Chris", "Robert", "Evans");

            // Act & Assert
            var exceptionEmptyCompanyName = Assert.Throws<ArgumentException>(() => new Employee(fullName, "chris.evans@company.com", string.Empty, "Actor", "987-65-4321", 42, "06-13-1981"));
            Assert.Equal("Company name cannot be null or empty. (Parameter 'companyName')", exceptionEmptyCompanyName.Message);
        }

        [Fact]
        public void Employee_ThrowsArgumentException_WhenPositionIsNullOrEmpty()
        {
            // Arrange
            var fullName = new FullName("Scarlett", "Ingrid", "Johansson");

            // Act & Assert
            var exceptionEmptyPosition = Assert.Throws<ArgumentException>(() => new Employee(fullName, "scarlett.johansson@company.com", "Marvel Studios", string.Empty, "123-45-6789", 39, "11-22-1984"));
            Assert.Equal("Position cannot be null or empty. (Parameter 'position')", exceptionEmptyPosition.Message);
        }
    }


