using Xunit;

namespace Logger.Tests;

public class TestEntityFromAbstractTests
{
    [Fact]
    public void Constructor_FirstAndLast_CreatesTestEntityFromAbstract()
    {
        //Arrange
        
        //Act
        TestEntityFromAbstract testEntityFromAbstract = new("first","last");

        //Assert
        Assert.NotNull(testEntityFromAbstract);
        Assert.Equal("first last", testEntityFromAbstract.Name);
    }
    [Fact]
    public void Constructor_FirstMiddleLast_CreatesTestEntityFromAbstract()
    {
        //Arrange

        //Act
        TestEntityFromAbstract testEntityFromAbstract = new("first", "last", "middle");

        //Assert
        Assert.Equal("first middle last", testEntityFromAbstract.Name);
    }
}