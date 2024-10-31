using Xunit;
namespace Logger.Tests;

public class EmployeeTests
{
    [Fact]
    public void EmployeeConstructorInitializesProperties()
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
        public void BaseEntityIdInitializedReturnsValidId()
        {
            // Arrange
            var employee = new Employee("John", "Doe", "Smith", "123-45-6789","john.doe@example.com", "1990-01-01", "Software Developer", "IT" );

            // Act
            var employeeEntity = (IEntity)employee;
            var id = employeeEntity.Id;
            

            // Assert
            Assert.NotEqual(Guid.Empty, id);
        }
    [Fact]
    public void EmployeeConstructorThrowsArgumentNullExceptionWhenPositionIsNull()
    {
        // Arrange
        var FullName = new FullName
        {
            FirstName = "John",
            MiddleName = "Doe",
            LastName = "Smith"
        };

        var email = "john.doe@example.com";

        string position = null!; // Set position to null
        var department = "IT";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            var employee = new Employee(FullName.FirstName, FullName.MiddleName, FullName.LastName, "123-45-6789", email, "1990-01-01", position, department);
        });
    }

    [Fact]
    public void EmployeeConstructorThrowsArgumentNullExceptionWhenDepartmentIsNull()
    {
        // Arrange
        var FullName = new FullName
        {
            FirstName = "John",
            MiddleName = "Doe",
            LastName = "Smith"
        };
        var email = "john.doe@example.com";
        var position = "Software Developer";
        string department = null!; // Set department to null

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            var employee = new Employee(FullName.FirstName, FullName.MiddleName, FullName.LastName, "123-45-6789", email, "1990-01-01", position, department);
        });
    }
}