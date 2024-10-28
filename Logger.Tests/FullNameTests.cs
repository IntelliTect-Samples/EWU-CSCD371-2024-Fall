using Xunit;
namespace Logger.Tests;

public class FullNameTests
{
    [Fact]
    public void FullName_WithOutMiddleName_ShouldReturnFullName()
    {
        //Arrange
        var fullName = new FullName("John", "Doe", "");
        //Act
        var result = fullName.ToString();
        //Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void FullName_WithNullMiddleName_ShouldReturnFullName()
    {
        //Arrange
        var fullName = new FullName("John", "Doe", null);
        //Act
        var result = fullName.ToString();
        //Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void FullName_WithNullMiddleName_MiddleNameIsNull()
    {
        //Arrange
        var fullName = new FullName("John", "Doe", null);
        //Act
        var result = fullName.ToString();
        //Assert
        Assert.Null(fullName.middleName);
    }


    [Fact]
    public void FullName_CompleteFullName_ShouldReturnFullName()
    {
        //Arrange
        var fullName = new FullName("John", "Doe", "W");
        //Act
        var result = fullName.ToString();
        //Assert
        Assert.Equal("John W Doe", result);
    }

    [Fact]
    public void FullName_CreateFullName_Success()
    {
        //Arrange
        var fullName = new FullName("John", "Doe", "W");
        //Act
        var result = fullName;
        //Assert
        Assert.Equal("John", result.firstName);
        Assert.Equal("W", result.middleName);
        Assert.Equal("Doe", result.lastName);
    }


}
