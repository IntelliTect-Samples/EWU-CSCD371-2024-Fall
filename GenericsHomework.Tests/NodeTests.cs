using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void Node_SetValue_newNodeEqualtoValue()
    {
        // Arrange
        int value = 5;

        // Act
        Node<int> newNode = new Node<int>(value);

        // Assert
        Assert.Equal(value, newNode.Value);

    }

    [Fact]
    public void NodeConstructor_AllowsHomogenousTypes_ValuesEqual()
    {
        // Arrange & Act
        Node<int> intNode = new Node<int>(10);
        Node<string> stringNode = new Node<string>("Hello");

        // Assert
        Assert.Equal(typeof(Node<int>), intNode.GetType());
        Assert.Equal(typeof(Node<string>), stringNode.GetType());
    }

    [Fact]
    public void ToString_OverrideToString_ExistsIsEqual()
    {
        // Arrange
        Node<int> intNode = new Node<int>(10);

        // Act & Assert
        Assert.Equal("Value: 10", intNode.ToString());
    }
}