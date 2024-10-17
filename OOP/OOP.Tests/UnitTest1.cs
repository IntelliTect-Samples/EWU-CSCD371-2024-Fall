namespace OOP.Tests;

public partial class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        DbStore dbStore = new();
        SampleObject startingObject = new(/*name*/);
        string data = dbStore.Save(startingObject);
        // If I have a wrong cast I will get an InvalidCastException

        // Act
        SampleObject result = (SampleObject)dbStore.LoadObject(data);

        // Assert
        Assert.Equivalent(startingObject, result);
        Assert.True(object.ReferenceEquals(startingObject, result));
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        DbStore dbStore = new();
        Person person = new();
        ((IPersist)person).LoadData("name");
        string data = dbStore.Save(person);
        // Act
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        DbStore dbStore = new();
        SampleObject startingObject = new(/*name*/);
        string data = dbStore.Save(startingObject);

        // Act
        StorageEx.LoadObject<SampleObject>(dbStore, data);
        SampleObject result = dbStore.LoadObject<SampleObject>(data);
    }
}

public static class StorageEx
{
    public static T LoadObject<T>(this IStorage storage, string data) where T : IPersist
    {
        return (T)storage.Load(data);
    }
}