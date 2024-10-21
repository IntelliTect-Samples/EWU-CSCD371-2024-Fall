using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class IEntityTests
{

    [Fact]
    public void MockEntity_SetAndGetProperties_Success()
    {
        //Arrange
        var mockEntity = new MockEntity();
        var newGuid = Guid.NewGuid();

        //Act
        mockEntity.Id = newGuid;
        mockEntity.Name = "Test Name";

        //Assert
        Assert.Equal(newGuid, mockEntity.Id);
        Assert.Equal("Test Name", mockEntity.Name);
    }
}

public class MockEntity : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
}

