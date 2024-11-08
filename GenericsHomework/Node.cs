namespace GenericsHomework;

public class Node<T>
{
    public T Value { get; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string ToString()
    {
        return Value?.ToString() ?? string.Empty;
    }

    public void Append(T value)
    {
        if (Exists(value))
        {
            throw new ArgumentException("No duplicates allowed!");
        }

        Node<T> newNode = new(value);
        Node<T> current = this;

        while (current.Next != this)
        {
            current = current.Next;
        }

        current.Next = newNode;
        newNode.Next = this;
    }
    public bool Exists(T value)
    {
        Node<T> current = this;

        do
        {
            // Check if the current node matches the value
            if ((current.Value == null && value == null) ||
                (current.Value != null && current.Value.Equals(value)))
            {
                return true;
            }
            current = current.Next;
        } while (current != this);

        return false;
    }
    public void Clear()
    {
        Node<T> current = this.Next;
        Node<T> previous = this;

        /* 
            In order for garbage collection to pickup the cleared nodes, they must be unreachable.
            If the linked list was used with a singular Node as a point of entry, just setting it's Next to itself would be sufficient, 
            however it is possible that a Node is instantiated with the next pointer, therefore we opted to
            iterate through the entire list to ensure all Nodes are unreachable.
        */
        while (current != this)
        {
            Node<T> nextNode = current.Next;
            previous.Next = previous;
            current = nextNode;
        }

        this.Next = this;
    }
}
