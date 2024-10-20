using Xunit;

namespace Logger.Tests;

public class IEntityTests
{
    [Fact]
    public void Constructor_ValidInputs_CreatesValidTestEntity()
    {
        //Arrange
        Guid guid = Guid.NewGuid();

        //Act
        var entity = new TestEntity() { Name = "My Full Name", Id = guid };

        //Assert
        Assert.NotNull(entity);
        Assert.Equal("My Full Name", entity.Name);
        Assert.Equal(guid, entity.Id);

    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" \n")]

    public void Constructor_InvalidName_ThrowsException(string? name)
    {
        //Arrange
        Guid guid = new();
        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => new TestEntity() { Id =guid,Name = name! });
    }
}
