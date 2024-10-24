using Xunit;

namespace Logger.Tests;

public class FullNameTests
{
    [Fact]
    public void PrintFullName_AllArguments_ReturnsFullName()
    {

        // 1. Arrange
        FullName fullName = new("John", null,"Doe");

        //2. Act
        var result = fullName.ToString();

        //3. Assess
        Assert.Equal("John Doe", result);
    }
}
