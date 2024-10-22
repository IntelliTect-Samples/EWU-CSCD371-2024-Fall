using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        var mockEntity = new MockEntity("TestName");

        //Act

        //Assert
        Assert.NotEqual(Guid.Empty, mockEntity.Id);
        Assert.Equal("TestName", mockEntity.Name);
    }
}

public class MockEntity : IEntity
{
    public MockEntity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
}

