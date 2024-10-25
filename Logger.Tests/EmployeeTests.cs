using Xunit;

namespace Logger.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Employee_SetProperties_Success()
        {
            // Arrange & Act
            var employee = new Employee(new FullName("Chris", "Cornell", "J"), "CEO", "BOSS");

            // Assert
            Assert.Equal("Chris J Cornell", employee.FullName.ToString());
            Assert.Equal("CEO", employee.Position);
            Assert.Equal("BOSS", employee.Department);
        }

        [Fact]
        public void Employee_ShouldHaveUniqueId()
        {
            // Arrange
            var employee1 = new Employee(new FullName("Chris", "J", "Cornell"), "CEO", "BOSS");
            var employee2 = new Employee(new FullName("Bob", "", "Barker"), "Legend", "BOSS");

            // Assert
            Assert.NotEqual(employee1.Id, employee2.Id);
        }

        [Fact]
        public void FullName_EmptyMiddleName_ShouldSetMiddleNameToNull()
        {
            // Arrange
            var fullName = new FullName("Chris", "Cornell", "");

            // Act & Assert
            Assert.Null(fullName.MiddleName);           
        }
    }
}
