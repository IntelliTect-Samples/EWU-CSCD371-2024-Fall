using Xunit;

namespace Logger.Tests;

public class StorageTest
{
    [Fact]
    public void Storage_AddNewStudent_Successful()
    {
        // Arrange  
        Storage storage = new();
        IEntity student = new Student("John", "Doe", "Smith",
            "john.doe@example.com","Eastern", 2024, "Computer Science", "1234567890", 20, "10-5-2004");



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
        IEntity student = new Student("Joe", "Deer", "Danson",
            "Joedeer@ewu.edu", "Eastern", 2024, "Arts", "2345872390", 34, "10-5-1990");
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
        Assert.Null(retrievedID);
    }

}