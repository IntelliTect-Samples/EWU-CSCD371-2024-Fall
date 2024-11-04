
using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{

    [Fact]
    public void Append_ValidValue_AppendsNodeToList()
    {
        // Arrange
        Node<int> node = new(23);

        // Act
        node.Append(99);

        // Assert
        Assert.Equal(99, node.Next.Value);
        Assert.Same(node, node.Next.Next); // should point back to node.
    }

    [Fact]
    public void Clear_RemovesNodes_ExceptSelf()
    {
        // Arrange
        Node<int> node = new(10);
        node.Append(20);
        node.Append(30);

        // Act
        node.Clear();

        // Assert
        Assert.Same(node, node.Next);
        Assert.Equal(10, node.Value);
        Assert.False(node.Exists(20));
        Assert.False(node.Exists(30));
    }

}
