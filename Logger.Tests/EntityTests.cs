using System.Reflection;
using Xunit;

namespace Logger.Tests;
public class EntityTests
{

    [Fact]
    public void EntityClass_EntityClass_Exists()
    {
        // Arrange
        // Get the assembly where Entity is supposed to be defined
        Assembly assembly = Assembly.GetAssembly(typeof(Entity)); // Assuming EntityBase is in the same assembly

        // Act
        // Attempt to get the type of Entity
        Type entityType = assembly.GetType("Logger.Entity"); // Adjust the namespace if necessary

        // Assert
        Assert.NotNull(entityType);
    }

    [Fact]
    public void Entity_Should_Implement_IEntity_Interface_With_Instance()
    {
        // Arrange
        var entity = new Entity { Id = Guid.NewGuid(), Name = "Test Entity" };

        // Act & Assert
        Assert.IsAssignableFrom<IEntity>(entity);
    }


}
