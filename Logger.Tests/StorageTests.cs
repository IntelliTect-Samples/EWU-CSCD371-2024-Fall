using Xunit;

namespace Logger.Tests;

public class StorageTests
{
    [Fact]
    public void Constructor_InitializedStorage_Success()
    {
        Storage storage = new();

        Assert.NotNull(storage);
    }

    [Fact]
    public void Add_Entity_Success()
    {
        Storage storage = new();
        FullName fullName = new("Inigo", "Montoya");
        Student student = new(fullName, "imontoya1", 1, true, 4.0, "Revenge");

        storage.Add(student);

        Assert.True(storage.Contains(student));
    }

    [Fact]
    public void Remove_Entity_Success()
    {
        Storage storage = new();
        FullName fullName = new("Inigo", "Montoya");
        Student student = new(fullName, "imontoya1", 1, true, 4.0, "Revenge");

        storage.Add(student);
        storage.Remove(student);

        Assert.False(storage.Contains(student));
    }

    [Fact]
    public void Get_Entity_Success()
    {
        Storage storage = new();
        FullName fullName = new("Inigo", "Montoya");
        Student student = new(fullName, "imontoya1", 1, true, 4.0, "Revenge");

        storage.Add(student);

        Guid studentId = ((IEntity)student).Id;

        IEntity? result = storage.Get(studentId);

        Assert.NotNull(result);
        Assert.IsType<Student>(result);
        Assert.Equal(student, result);
    }

    [Fact]
    public void Get_EntityNotInStorage_ReturnsNull()
    {
        Storage storage = new();
        FullName fullName = new("Inigo", "Montoya");
        Student student = new(fullName, "imontoya1", 1, true, 4.0, "Revenge");

        Assert.Null(storage.Get(((IEntity)student).Id));
    }
}
