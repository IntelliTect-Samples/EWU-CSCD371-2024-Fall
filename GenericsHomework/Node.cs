namespace GenericsHomework;

public class Node<T>
{
    // Value that will be held by the node
    public T Value { get; }

    // Reference to the next node
    public Node<T> Next { get; private set; }

    // initialize the node with a value
    // set the Next reference to itself which makes it circular
    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string ToString()
    {
        return Value?.ToString() ?? string.Empty;
    }

}


