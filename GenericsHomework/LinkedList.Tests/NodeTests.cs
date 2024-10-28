namespace CircularLinkedList.Tests;

public class NodeTests
{
    [Theory]
    [InlineData(13)]
    [InlineData(13.0)]
    [InlineData("Hello!")]
    public void Constructor_VariousDataTypes_Exists<T>(T value)
    {
        // Arrange
        Node<T> node = new(value);

        // Act

        // Assert
        Assert.NotNull(node);
    }

    [Theory]
    [InlineData(13)]
    [InlineData(13.0)]
    [InlineData("Hello!")]
    public void Constructor_VariousDataTypes_ContainsExpectedDataTypes<T>(T value)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        Type expectedType = typeof(T);
        Type actualType = node.Value!.GetType();

        // Assert
        Assert.Equal(expectedType, node.Value.GetType());
    }

    [Fact]
    public void Next_NodeOnCreation_NextReferencesItself()
    {
        // Arrange
        int value = 13;

        // Act
        Node<int> node = new(value);

        // Assert
        Assert.Same(node, node.Next);
    }
}