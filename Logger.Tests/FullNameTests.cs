using Xunit;

namespace Logger.Tests;

public class FullNameTests
{
    [Fact]
    public void PrintName_AllArgumentsNullMiddle_ReturnsFirstLastName()
    {

        // 1. Arrange
        FullName fullName = new("John", null,"Doe");

        //2. Act
        var result = fullName.ToString();

        //3. Assess
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void PrintFullName_AllArgumentsNoNullMiddle_ReturnsFullName()
    {

        // 1. Arrange
        FullName fullName = new("John", "Michael", "Doe");

        //2. Act
        var result = fullName.ToString();

        //3. Assess
        Assert.Equal("John Michael Doe", result);
    }

    [Fact]
    public void NullFirstName_AllArgumentsNullFirst_ThrowsNullException()
    {
        // Arrange, Act & Assess
        Assert.Throws<ArgumentNullException>(() => new FullName(null, "Michael", "Doe"));
    }
}
