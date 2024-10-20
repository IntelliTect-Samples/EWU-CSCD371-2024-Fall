using System.Reflection;
using Xunit;

namespace Logger.Tests;

public class FullNameTests
{
    [Theory]
    [InlineData("First", "middle", "Last", "First", "middle", "Last")]

    public void Constructor_AllParameters_MakesRecord(string first, string middle, string last, string expectedFirst,string expectedMiddle, string expectedLast)
    {
        //Arrange
        //Act

        FullName f = new() { First = first,Last = last, Middle = middle };
        //Assert
        Assert.NotNull(f);
        Assert.Equal( expectedFirst, f.First);
        Assert.Equal(expectedMiddle, f.Middle);
        Assert.Equal(expectedLast, f.Last);
        
    }
    [Theory]
    [InlineData("First","Last","First", "Last")]
    public void Constructor_NoMiddleName_MakesRecord(string first,string last,string expectedFirst,string expectedLast)
    {
        //Arrange

        //Act
        FullName fullName = new() { First = first, Last = last};

        //Assert
        Assert.NotNull (fullName);
        Assert.Equal (expectedFirst, fullName.First);
        Assert.Equal(expectedLast , fullName.Last);
        Assert.Equal(first+""+last, fullName.First+fullName.Middle+fullName.Last);
    }
    [Theory]
    [InlineData(null,"last", "middle")]
    [InlineData("first",null,"middle")]
    [InlineData("first", "last", null)]
    public void Constructor_BadValues_ThrowsException(string? first, string? last, string? middle)
    {
        //Arrange
        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(() =>new FullName() { First = first!, Last = last!, Middle = middle });
    }
}
