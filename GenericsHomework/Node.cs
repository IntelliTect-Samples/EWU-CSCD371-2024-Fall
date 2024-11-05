namespace GenericsHomework;

public class Node<T>
{
    public T Value { get; }
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

    public void Append(T value)
    {
        if (Exists(value))
        {
            throw new ArgumentException("No duplicates allowed!");
        }

        Node<T> newNode = new(value);
        Node<T> current = this;

        // Traverse to the last node
        while (current.Next != this)
        {
            current = current.Next;
        }

        // Insert the new node at the end and point it back to the first node
        current.Next = newNode;
        newNode.Next = this;
    }
    public bool Exists(T value)
    {
        // Start at current node
        Node<T> current = this;

        // Traverse the list
        do
        {
            // Check if the current node matches the value
            if ((current.Value == null && value == null) ||
                (current.Value != null && current.Value.Equals(value)))
            {
                return true;
            }
            current = current.Next;
        } while (current != this); // Continue until back to start

        return false;
    }
    public void Clear()
    {
        // Start from the node after the current node
        Node<T> current = this.Next;
        Node<T> previous = this;

        // Traverse and disconnect each node
        while (current != this)
        {
            Node<T> nextNode = current.Next; // Save the next node
            previous.Next = previous;        // Disconnect the current node
            current = nextNode;              // Move to the next node
        }

        // Reset next to point back to itself
        this.Next = this;
    }
}
