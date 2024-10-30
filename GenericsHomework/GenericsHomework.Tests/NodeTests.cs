using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void CreateSingleNode_PointsToSelf_True()
    {
        // Arrange
        var node = new Node<int>(42);

        // Assert
        Assert.Equal(node, node.Next);
    }

    [Fact]
    public void Node_ToString_ReturnsData()
    {
        // Arrange
        var node = new Node<int>(42);

        // Assert
        Assert.Equal("Data: 42", node.ToString());
    }

    [Fact]
    public void Append_ListSizeOne_Success()
    {
        // Arrange
        var node = new Node<int>(42);

        // Act
        node.Append(43);

        // Assert
        Assert.Equal(43, node.Next.Data);
        Assert.Equal(node, node.Next.Next);
    }

    [Fact]
    public void Append_ListMoreThanOne_Success()
    {
        // Arrange
        var node = new Node<int>(42);
        node.Append(43);

        // Act
        node.Append(44);

        // Assert
        Assert.Equal(43, node.Next.Next.Data);
        Assert.Equal(node, node.Next.Next.Next);
    }

    [Fact]
    public void Append_DuplicateValue_ThrowsException()
    {
        // Arrange
        var node = new Node<int>(42);
        node.Append(43);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => node.Append(43));
    }

    [Fact]
    public void Clear_ClearsListExceptCurrentNode_Success()
    {
        // Arrange
        var node = new Node<int>(42);
        node.Append(43);
        node.Append(44);
        node.Append(45);
        node.Append(46);

        // Act
        node.Clear();

        // Assert
        Assert.Equal(node, node.Next);
        Assert.Equal(42, node.Data);
    }

}