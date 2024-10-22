using Xunit;

namespace Logger.Tests;

public class EmployeeTests
{
    [Fact]
    public void Constructor_AllParamaters_MakesEmployee()
    {
        //Arrange
        Employee employee = new("EmployeeID", "Position", "First", "Last", "Middle");

        //Act

        //Assert
        Assert.NotNull(employee);
    }
}
