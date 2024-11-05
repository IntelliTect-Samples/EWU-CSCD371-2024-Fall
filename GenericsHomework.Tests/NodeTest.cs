namespace GenericsHomework.Tests;
using System;
using Xunit;

public class NodeTests
{
    [Fact]
    public void Append_NullData_ThrowsArgumentNullException()
    {
        // Arrange
        Node<string> node = new Node<string>("data");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => node.Append(null!));
    }

    [Fact]
    public void Append_ExistingData_ThrowsInvalidOperationException()
    {
        // Arrange
        Node<int> node = new Node<int>(1);
        node.Append(2);
        node.Append(3);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => node.Append(2));
    }

    [Fact]
    public void Exists_DataExists_ReturnsTrue()
    {
        // Arrange
        Node<int> node = new Node<int>(1);
        node.Append(2);
        node.Append(3);

        // Act
        bool exists = node.Exists(2);

        // Assert
        Assert.True(exists);
    }

    [Fact]
    public void Exists_DataDoesNotExist_ReturnsFalse()
    {
        // Arrange
        Node<int> node = new Node<int>(1);
        node.Append(2);
        node.Append(3);

        // Act
        bool exists = node.Exists(4);

        // Assert
        Assert.False(exists);
    }

    [Fact]
    public void Clear_RemovesAllNodes()
    {
        // Arrange
        Node<int> node = new Node<int>(1);
        node.Append(2);
        node.Append(3);

        // Act
        node.Clear();

        // Assert
        Assert.Null(node.Next);
    }
    [Fact]
    public void ToString_ReturnsDataAsString()
    {
        // Arrange
        Node<int> node = new Node<int>(42);

        // Act
        string result = node.ToString();

        // Assert
        Assert.Equal("42", result);
    }
}