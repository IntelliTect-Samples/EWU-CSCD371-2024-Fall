using Xunit;

namespace Logger.Tests;

public class FullNameTests
{
    [Fact]
    public void PrintName_AllArgumentsNullMiddle_ReturnsFirstLastName()
    {

        // Arrange
        FullName fullName = new("John", "","Doe");

        // Act
        var result = fullName.ToString();

        // Assess
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void PrintFullName_AllArgumentsNoNullMiddle_ReturnsFullName()
    {

        // Arrange
        FullName fullName = new("John", "Michael", "Doe");

        // Act
        var result = fullName.ToString();

        // Assess
        Assert.Equal("John Michael Doe", result);
    }
}
