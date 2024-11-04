
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

}

