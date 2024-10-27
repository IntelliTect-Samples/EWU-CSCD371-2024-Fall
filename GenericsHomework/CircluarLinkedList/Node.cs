namespace CircluarLinkedList;

public class Node<T>
{
    public T? Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T? value)
    {
        Value = value;
        Next = this;
    }

    public void Append(T? val)
    {
        Node<T> newNode = new(val);
        Node<T> lastNode = Next;
        newNode.Next = lastNode;
        Next = newNode;
    }

    public override string? ToString()
    {
        return Value?.ToString();
    }

    public bool Exists(T? expectedValue)
    {
        Node<T> current = this;

        do
        {
            if ( (current.Value is null && expectedValue is null) ||current.Value!.Equals(expectedValue) == true )
            {
                return true;
            }
            current = current.Next;
        } while (current != this);

        return false;
    }
}