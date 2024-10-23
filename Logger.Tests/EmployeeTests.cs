using Xunit;
namespace Logger.Tests;

public class EmployeeTests
{
    [Fact]
    public void Name_SetValid_Success()
    {
        // Arrange
        Employee employee = new()
        {
            Name = "123456: Billy Jean: Singer"
        };

        // Act

        // Assert
        Assert.Equal("123456: Billy Jean: Singer", employee.Name);
    }

    [Fact]
    public void Name_SetInvalidId_FormatException()
    {
        // Arrange
        Employee employee = new();

        // Act

        // Assert
        Assert.Throws<FormatException>(() => employee.Name = "123A456: Billy Jean: Engineer");
    }

    [Fact]
    public void Name_SetInvalidNameLength_FormatException()
    {
        // Arrange
        Employee employee = new();

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => employee.Name = "123456: Billy Jean Tommy Bean: Engineer");
    }

    [Fact]
    public void Name_SetNull_ArgumentNullException()
    {
        // Arrange
        Employee employee = new();

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => employee.Name = null!);
    }

    [Fact]
    public void Name_SetEmpty_ArgumentException()
    {
        // Arrange
        Employee employee = new();

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => employee.Name = "");
    }
}
