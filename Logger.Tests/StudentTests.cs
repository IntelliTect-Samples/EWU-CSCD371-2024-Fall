using Xunit;

namespace Logger.Tests;

public class StudentTests
{
    [Fact]
    public void StudentName_SetValid_Success()
    {
        // Arrange
        Student student = new()
        {
            StudentName = new FullName("Billy", "Jean")
        };

        // Act

        // Assert
        Assert.Equal(new FullName("Billy", "Jean"), student.StudentName);
    }

    //[Fact]
    //public void StudentName_SetNull_ArgumentNullException()
    //{
    //    // Arrange
    //    Student student = new Student();
    //    student.StudentName = new FullName("Billy", null!);

    //    // Act

    //    // Assert
    //    Assert.Equal(new FullName("Billy", "Jean"), student.StudentName);
    //}

    [Fact]
    public void StudentId_SetValid_Success()
    {
        // Arrange
        Student student = new()
        {
            StudentId = 123456
        };

        // Act

        // Assert
        Assert.Equal(123456, student.StudentId);
    }

    //[Fact]
    //public void StudentId_SetNull_ArgumentNullException()
    //{
    //    // Arrange
    //    Student student = new Student();
    //    student.StudentId = null!;

    //    // Act

    //    // Assert
    //    Assert.Equal(123456, student.StudentId);
    //}

    [Fact]
    public void Name_SetValid_Success()
    {
        // Arrange
        Student student = new()
        {
            Name = "123456: Billy Jean"
        };

        // Act

        // Assert
        Assert.Equal("123456: Billy Jean", student.Name);
    }

    [Fact]
    public void Name_SetInvalidId_FormatException()
    {
        // Arrange
        Student student = new();

        // Act

        // Assert
        Assert.Throws<FormatException>(() => student.Name = "123A456: Billy Jean");
    }

    [Fact]
    public void Name_SetInvalidNameLength_FormatException()
    {
        // Arrange
        Student student = new();

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => student.Name = "123456: Billy Jean Tommy Bean");
    }

    [Fact]
    public void Name_SetNull_ArgumentNullException()
    {
        // Arrange
        Student student = new();

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => student.Name = null!);
    }

    [Fact]
    public void Name_SetEmpty_ArgumentException()
    {
        // Arrange
        Student student = new();

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => student.Name = "");
    }
}
