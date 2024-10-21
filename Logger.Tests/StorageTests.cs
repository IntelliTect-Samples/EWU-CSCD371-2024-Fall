using System;
using Xunit;

namespace Logger.Tests;

public class StorageTests
{
    [Fact]
    public void constructor_DVC_CreatesStorage()
    {
        //Arrange
        Storage storage = new();
        //Act

        //Assert
        Assert.NotNull(storage);

    }


}
