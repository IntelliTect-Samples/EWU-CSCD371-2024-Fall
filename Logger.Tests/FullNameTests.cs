using Xunit;

namespace Logger.Tests;

public class FullNameTests
{
    [Fact]
    public void Create_FullName_Success()
    {
        // Arrange
        FullName testName = new("Kevin", "Riain", "Flannery");
        // Act

        // Assert
        Assert.Equal("Kevin", testName.FirstName);
        Assert.Equal("Riain", testName.MiddleName);
        Assert.Equal("Flannery", testName.LastName);
    }

    [Fact]
    public void Create_FullNameWithoutMiddleName_Success()
    {
        // Arrange
        FullName testName = new("Kevin", "Flannery");
        // Act

        // Assert
        Assert.Equal("Kevin", testName.FirstName);
        Assert.Null(testName.MiddleName);
        Assert.Equal("Flannery", testName.LastName);
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

    //[Fact]
    //public void Create_FullNameWithNull_ArgumentNullException()
    //{
    //    // Arrange
    //    FullName testName;
    //    // Act

    //    // Assert
    //    Assert.Throws<ArgumentNullException>(() => testName = new FullName(null!, null!));
    //}
}
