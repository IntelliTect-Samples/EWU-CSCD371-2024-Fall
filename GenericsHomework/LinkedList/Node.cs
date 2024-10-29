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
        Node<T> current = this;
        while (current.Next != this)
        {
            current = current.Next;
        }
        current.Next = node;
        node.Next = this;
    }

    public void Clear()
    {
        Node<T> cur = this.Next;
        while (cur != this)
        {
            Node<T> temp = cur;
            cur = cur.Next;
            temp.Next = null!;
        }
        this.Next = this;
    }
}