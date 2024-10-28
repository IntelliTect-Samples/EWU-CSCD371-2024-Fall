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

    // TODO: Check how to test complex objects such as an array with multiple values
    [Theory]
    [InlineData("Data!")]
    [InlineData("")]
    [InlineData(42)]
    [InlineData([32])]
    public void ToString_GivenData_ReturnsExpectedValue<T>(T value)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        string nodeOut = node.ToString();

        // Assert
        Assert.Equal(nodeOut, $"{node.Value}");
    }

    [Theory]
    [InlineData(null)]
    public void ToString_Null_ReturnsExpectedValue<T>(T value)
    {
        // Arrange
        Node<T> node = new(value);
        string expectedOut = "Value does not exist.";

        // Act
        string nodeOut = node.ToString();

        // Assert
        Assert.Equal(expectedOut, nodeOut);
    }

    [Fact]
    public void Append_GivenData_NextPointsAsExpected()
    {
        // Arrange
        Node<int> node = new(13);

        // Act
        node.Append(42);

        // Assert
        Assert.Equal(node, node.Next.Next);
        Assert.Equal(node.Next, node.Next.Next.Next);
        Assert.NotEqual(node.Next, node);
    }

    [Theory]
    [InlineData(13, 42)]
    [InlineData(13.0, 12.0)]
    [InlineData("Hello!", "Goodbye")]
    public void Append_GivenData_AppendsData<T>(T value, T value2)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        node.Append(value2);

        // Assert
        Assert.Equal(value, node.Value);
        Assert.Equal(value2, node.Next.Value);
        Assert.Equal(value, node.Next.Next.Value);
        Assert.Equal(value2, node.Next.Next.Next.Value);
        Assert.NotEqual(value, node.Next.Value);
        Assert.NotEqual(value2, node.Next.Next.Value);
    }
}