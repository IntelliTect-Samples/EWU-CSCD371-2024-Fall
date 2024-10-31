using Xunit;
namespace Logger.Tests;

public class EmployeeTests
{
    [Fact]
    public void Employee_Constructor_InitializesProperties()
    {
        // Arrange
        var FullName = new FullName
        {
            FirstName = "John",
            MiddleName = "Doe",
            LastName = "Smith"
        };
        var ssn = "123-45-6789";
        var email = "john.doe@example.com";
        var dateOfBirth = "1990-01-01";
        var position = "Software Developer";
        var department = "IT";
        // Act
        var employee = new Employee(FullName.FirstName, FullName.MiddleName, FullName.LastName, "123-45-6789", email, "1990-01-01", position, department);

        // Assert
        Assert.Equal(FullName.ToString(), employee.FullName.ToString());
        Assert.Equal(FullName, employee.FullName);
        Assert.Equal(ssn, employee.Ssn);
        Assert.Equal(email, employee.Email);
        Assert.Equal(dateOfBirth, employee.DateOfBirth);
        Assert.Equal(position, employee.Position);
        Assert.Equal(department, employee.Department);
    }
        [Fact]
        public void BaseEntity_IdInitialized_ReturnsValidId()
        {
            // Arrange
            var employee = new Employee("John", "Doe", "Smith", "123-45-6789","john.doe@example.com", "1990-01-01", "Software Developer", "IT" );

            // Act
            var employeeEntity = (IEntity)employee;
            var id = employeeEntity.Id;
            

            // Assert
            Assert.NotEqual(Guid.Empty, id);
        }
}