namespace CircularLinkedList.Tests;

public class NodeTests
{
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

    [Theory]
    [InlineData(42, 42)]
    [InlineData(42.0, 42.0)]
    [InlineData("42", "42")]
    public void Append_DuplicateValues_ThrowsException<T>(T value1, T value2)
    {
        // Arrange
        Node<T> node = new(value1);

        // Act

        // Assert
        Assert.Throws<InvalidOperationException>(() => node.Append(value2));
    }

    [Theory]
    [InlineData(42, 43, 42)]
    [InlineData(42.0, 43.0, 42.0)]
    [InlineData("fortytwo", "fortythree", "fortytwo")]
    public void Append_DuplicateValues_MessagBeingDisplayedIsCOrrect<T>(T value, T value2, T value3)
    {
        // Arrange
        Node<T> node = new(value);
        node.Append(value2);
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => node.Append(value3));
        string expectedMessage = "Value already exists in this list.";

        // Act
        string actualMessage = ex.Message;

        // Assert
        Assert.Equal(expectedMessage, actualMessage);
    }

    //TODO: Add test to check for multiple appends
    [Theory]
    [InlineData(13, 42, 18)]
    [InlineData(13.0, 12.0, 14.0)]
    [InlineData("Hello!", "Goodbye", "Auf wiedersehen")]
    public void Append_MoreGivenData_AppendsData<T>(T value, T value2, T value3)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        node.Append(value2);
        node.Append(value3);

        // Assert
        Assert.Equal(value, node.Value);
        Assert.Equal(value2, node.Next.Value);
        Assert.Equal(value3, node.Next.Next.Value);
        Assert.Equal(value, node.Next.Next.Next.Value);
        Assert.Equal(value2, node.Next.Next.Next.Next.Value);
        Assert.Equal(value3, node.Next.Next.Next.Next.Next.Value);
        Assert.NotEqual(value, node.Next.Value);
        Assert.NotEqual(value2, node.Next.Next.Value);
        Assert.NotEqual(value3, node.Next.Next.Next.Value);
    }

    [Theory]
    [InlineData(42, 43, 48)]
    [InlineData(42.0, 43.0, 44.0)]
    [InlineData("fortytwo", "fortythree", "fortyfour")]
    public void Clear_GivenMoreData_ClearsItemsExceptCurrentNode<T>(T value, T value2, T value3)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        node.Append(value2);
        node.Append(value3);
        node.Clear();

        // Assert
        Assert.Equal(node, node.Next);
        Assert.Equal(value, node.Next.Value);
        Assert.NotEqual(value2, node.Value);
        Assert.NotEqual(value3, node.Value);
    }

    [Theory]
    [InlineData(42, 43, 48, 49)]
    [InlineData(42.0, 43.0, 44.0, 45.0)]
    [InlineData("fortytwo", "fortythree", "fortyfour", "fortyfive")]
    public void Exists_NodeList_ContainsValue<T>(T value, T value2, T value3, T value4)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        node.Append(value2);
        node.Append(value3);
        node.Append(value4);

        // Assert
        Assert.True(node.Exists(value));
        Assert.True(node.Exists(value2));
        Assert.True(node.Exists(value3));
        Assert.True(node.Exists(value4));
    }

    [Theory]
    [InlineData(null)]
    public void Exists_Null_ReturnsFalse<T>(T value)
    {
        // Arrange
        Node<T> node = new(value);

        // Act

        // Assert
        Assert.False(node.Exists(value));
    }
    
    [Theory]
    [InlineData("42", null)]
    public void Exists_ValueAndNull_ReturnsFalse<T>(T value, T value2)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        node.Append(value2);

        // Assert
        Assert.False(node.Exists(node.Next.Value));
    }
}