namespace GenericsHomework;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string? ToString()
    {
        return Value?.ToString();
    }

    public void Append(T value)
    {
        if(Exists(value))
            throw new InvalidOperationException("Value already exists in the list");

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
            if (current.Value is not null && current.Value.Equals(value) || current.Value is null && value is null)
                return true;
            current = current.Next;
        } while (current != this);
        return false;
    }

    /* 
     * By making next reference to itself, we sever the link to the rest of the list,
     * which will cause the garbage collector to clean up the rest of the list.
     * Since the severed list has no references to it, it will be cleaned up and we don't need
     * to worry about garbage collection not cleaning up the list.
    */
    public void Clear()
    {
        Next = this;
    }

}
