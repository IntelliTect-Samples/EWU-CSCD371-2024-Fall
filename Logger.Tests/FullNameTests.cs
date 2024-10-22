using Xunit;

namespace Logger.Tests;

public class FullNameTests
{
    [Fact]
    public void Create_FullName_Success()
    {
        // Arrange
        FullName testName = new FullName("Kevin", "Riain", "Flannery");
        // Act

        // Assert
        Assert.Equal("Kevin", testName.firstName);
        Assert.Equal("Riain", testName.middleName);
        Assert.Equal("Flannery", testName.lastName);
    }

    [Fact]
    public void Create_FullNameWithoutMiddleName_Success()
    {
        // Arrange
        FullName testName = new("Kevin", "Flannery");
        // Act

        // Assert
        Assert.Equal("Kevin", testName.firstName);
        Assert.Null(testName.middleName);
        Assert.Equal("Flannery", testName.lastName);
    }

    [Fact]
    public void ToString_Success()
    {
        // Arrange
        FullName testName = new("Kevin", "Riain", "Flannery");
        // Act
        string result = testName.ToString();
        // Assert
        Assert.Equal("Kevin Riain Flannery", result);
    }
}
