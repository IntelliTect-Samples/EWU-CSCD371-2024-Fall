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

    // Appends a new node right in front of this node
    public void Append(T value)
    {
        // Exception for duplicate values
        if (Exists(value)) throw new ArgumentException(nameof(value));

        Node<T> newNode = new(value)
        {
            Next = this.Next
        };

        this.Next = newNode;
    }

    // The .NET garbage collector will handle the removed nodes, even if they point to each other.
    // The garbage collector will see that nothing outside of the list is pointing to the nodes, and clean it up automatically.
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

