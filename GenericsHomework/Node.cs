namespace GenericsHomework;

public class Node<T>
{
    public T? Value { get; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string? ToString() => Value?.ToString();

    public void Append(T value)
    {
        Node<T> newNode = new(value)
        {
            Next = this.Next
        };

        this.Next = newNode;
    }

    public void Clear()
    {
        Node<T> current = this;

        while(current.Next != this)
        {
            Node<T> next = current.Next;
            current.Next = this;
            current = next;
        }
    }

    public bool Exists(T value)
    {
        Node<T> current = this;
        do
        {
            bool? b = current.Value?.Equals(value);
            // b will not be null when it gets here, null checked above
            if (b!.Value)
            {
                return true;
            }
            current = current.Next;
        } while (current != this);

        return false;
    }
}

