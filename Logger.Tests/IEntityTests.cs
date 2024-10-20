using Xunit;

namespace Logger.Tests;

public class IEntityTests
{
    [Fact]
    public void Constructor_ValidInputs_IDK()
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
}
