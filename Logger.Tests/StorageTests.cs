using Xunit;

namespace Logger.Tests;

public class StorageTest
{
    [Fact]
    public void StudentEntityAddEntitySuccessful()
    {
        // Arrange
        Storage storage = new();
        IEntity student = new Student(new FullName("Joaquín", "", "Guzmán"), 
            "ElChapo@gmail.com", "1234567890", "Sinaloa", "Senior", 
            "Criminal Justice");

        // Act
        storage.Add(student);

        // Assert
        Assert.True(storage.Contains(student));
    }

    [Fact]
    public void StudentEntityRemoveEntitySuccessful()
    {
        // Arrange
        Storage storage = new();
        IEntity student = new Student(new FullName("Kate ", "", "del Castillo"), 
            "ElChapo@gmail.com", "8187996700", "Mexico City", "Junior", 
            "Journalism");
        storage.Add(student);

        // Act
        storage.Remove(student);

        // Assert
        Assert.False(storage.Contains(student));
    }
    
    

    [Fact]
    public void GetNonExistingEntityReturnsNull()
    {
        // Arrange
        Storage storage = new();
        Guid guid = Guid.NewGuid();

        // Act
        var retrievedEntity = storage.Get(guid);

        // Assert
        Assert.Null(retrievedEntity);
    }
}
