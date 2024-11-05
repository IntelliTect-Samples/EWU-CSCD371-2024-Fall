namespace GenericsHomework.Tests;
using System;
using Xunit;

public class NodeTests
{
    [Fact]
    public void AppendNullDataThrowsArgumentNullException()
    {
        // Arrange
        Node<string> node = new("data");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => node.Append(null!));
    }

    [Fact]
    public void AppendExistingDataThrowsInvalidOperationException()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => node.Append(2));
    }

    [Fact]
    public void ExistsDataExistsReturnsTrue()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        // Act
        bool exists = node.Exists(2);

        // Assert
        Assert.True(exists);
    }

    [Fact]
    public void ExistsDataDoesNotExistReturnsFalse()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        // Act
        bool exists = node.Exists(4);

        // Assert
        Assert.False(exists);
    }

    [Fact]
    public void ClearRemovesAllNodes()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        // Act
        node.Clear();

        // Assert
        Assert.Null(node.Next);
    }
    [Fact]
    public void ToStringReturnsDataAsString()
    {
        // Arrange
        Node<int> node = new(42);

        // Act
        string result = node.ToString();

        // Assert
        Assert.Equal("42", result);
    }
}