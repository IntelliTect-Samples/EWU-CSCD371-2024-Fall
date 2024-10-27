using Xunit;

namespace Logger.Tests;

public class StorageTest
{
    [Fact]
    public void Storage_AddEntity_Successful()
    {
        // Arrange
        Storage storage = new();
        IEntity student = new Student("Lewis", "Tony", "Stakeman",
            "LStakeman@gmail.com", "5123648362", "Seattle", "Junior",
            "Computer Science");

        // Act
        storage.Add(student);

        // Assert
        Assert.True(storage.Contains(student));
    }

    [Fact]
    public void Storage_RemoveEntity_Successful()
    {
        // Arrange
        Storage storage = new();
        IEntity student = new Student("Alexander", "", "Dewalt",
            "ADewalt@gmail.com", "63453453485", "Boise", "Freshman",
            "Art");
        storage.Add(student);

        // Act
        storage.Remove(student);

        // Assert
        Assert.False(storage.Contains(student));
    }



    [Fact]
    public void Get_ID_ReturnsNull()
    {
        // Arrange
        Storage storage = new();
        Guid guid = Guid.NewGuid();

        // Act
        var retrievedID = storage.Get(guid);

        // Assert
        Assert.Null(retrievedEntity);
    }