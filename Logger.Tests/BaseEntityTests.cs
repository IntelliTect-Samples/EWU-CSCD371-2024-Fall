using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class BaseEntityTests
{

    [Fact]
    public void Entity_Constructed_Exists()
    {
        // Arrange
        var entity = new TestEntity("Test");

        // Act
        var result = entity;

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Entity_HasId()
    {
        // Arrange
        var entity = new TestEntity("Test");

        // Act - Access the Id through IEntity
        var entityAsIEntity = (IEntity)entity;
        Guid result = entityAsIEntity.Id; // Cast to Guid since the Id is of type object

        // Assert
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public void Id_IsUnique_ForEachEntity()
    {
        // Arrange & Act
        var entity1 = new TestEntity("Test1");
        var entity2 = new TestEntity("Test2");

        // Access the Ids through IEntity
        var entity1AsIEntity = (IEntity)entity1;
        var entity2AsIEntity = (IEntity)entity2;

        Guid entity1Id = entity1AsIEntity.Id;
        Guid entity2Id = entity2AsIEntity.Id;

        // Assert
        Assert.NotEqual(entity1Id, entity2Id);
    }
}

public record class TestEntity(string testName) : EntityBase
{
    public override string Name { get; } = testName;
}