using System.Reflection;
using Xunit;

namespace Logger.Tests;
public class EntityTests
{

    [Fact]
    public void TestEntity_EntityBaseAndIEntityInterface_ReturnTrue()
    { 
        // Arrange
        var entity = new TestEntity();

        // Act & Assess
        Assert.IsAssignableFrom<IEntity>(entity);
    }


    // This is a private record class that implements the abstract class EntityBase. Used to test for IEntity implementation.
    private sealed record class TestEntity : EntityBase
    {
        public override string Name { get; set; }

        public TestEntity()
        {
            Id = Guid.NewGuid();
            Name = "TestEntity";
        }
    }
}
