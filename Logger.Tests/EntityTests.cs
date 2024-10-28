using System.Reflection;
using Xunit;

namespace Logger.Tests;
public class EntityTests
{
    //[Fact]
    //public void EntityClass_EntityClass_Exists()
    //{
    //    // Arrange
    //    // Get the assembly where Entity is supposed to be defined
    //    Assembly assembly = Assembly.GetAssembly(typeof(EntityBase)); // Assuming EntityBase is in the same assembly

    //    // Act
    //    // Attempt to get the type of Entity
    //    Type entityType = assembly.GetType("Logger.Entity"); // Adjust the namespace if necessary

    //    // Assert
    //    Assert.NotNull(entityType);
    //}

    [Fact]
    public void TestEntity_EntityBaseAndIEntityInterface_ReturnTrue()
    { 
        // Arrange
        var entity = new TestEntity();

        // Act & Assess
        Assert.IsAssignableFrom<IEntity>(entity);
    }


    // This is a private record class that implements the abstract class EntityBase. Used to test for IEntity implementation.
    private record class TestEntity : EntityBase
    {
        public override string Name { get; set; }

        public TestEntity()
        {
            Id = Guid.NewGuid();
            Name = "TestEntity";
        }
    }
}
