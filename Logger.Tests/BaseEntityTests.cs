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

        // Act
        var result = entity.Id;

        // Assert
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public void Id_IsUnique_ForEachEntity()
    {
        // Arrange & Act
        var entity1 = new TestEntity("Test1");
        var entity2 = new TestEntity("Test2");

        // Assert
        Assert.NotEqual(entity1.Id, entity2.Id);

    }

}

public class TestEntity(string name) : EntityBase
{
    public override string Name { get; init; } = name;
}