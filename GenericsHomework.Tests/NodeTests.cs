namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void ToString_Returns_ProperToString()
    {
        // Arrange
        Node<string> node = new("Toad");
        string toad = "Toad";
        // Act

        // Assert
        Assert.Equal(node.ToString(), toad.ToString());

    }


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
    public void Append_DuplicatedValue_ThrowsArgumentException()
    {
        // Arrange
        Node<int> node = new(10);
        
        // Act

        // Assert        
        Assert.Throws<ArgumentException>(() => node.Append(10));
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

    [Fact]
    public void Exists_GivenNonExistentValue_ReturnsFalse()
    {
        // Arrange
        Node<int> node = new(10);
        node.Append(20);
        node.Append(30);

        // Act

        // Assert
        Assert.False(node.Exists(40));
    }

    [Fact]
    public void Exists_GivenExistingValue_ReturnsTrue()
    {
        // Arrange
        Node<int> node = new(10);
        node.Append(20);
        node.Append(30);

        // Act

        // Assert
        Assert.True(node.Exists(20));
        Assert.True(node.Exists(10));
        Assert.True(node.Exists(30));
    }

}
