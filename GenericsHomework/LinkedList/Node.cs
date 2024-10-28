namespace CircularLinkedList;

public class Node<T>
{
    public T? Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string ToString()
    {
        return Value?.ToString() ?? $"{nameof(Value)} does not exist.";
    }

    public void Append(T value)
    {
        Node<T> node = new(value);
        node.Next = this.Next;
        this.Next = node;
    }
}