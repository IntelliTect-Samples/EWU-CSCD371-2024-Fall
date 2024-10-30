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
        if (Exists(val))
        {
            throw new ArgumentException("Value already exists in the list");
        }

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
            if ((current.Value is null && expectedValue is null) || current.Value?.Equals(expectedValue) == true)
            {
                return true;
            }
            current = current.Next;
        } while (current != this);

        return false;
    }



    // Given there is a circular list of items, we would need to worry about GC, as all the items point to each other and, therefore, may never be garbage collected. 
    // This can be solved by not fixing the loop, as we are not removing a node but instead clearing all but selected.

    //HOWEVER, if we want to ensure each node has no connections to Next, we using Next = this; is not enough.
    public void Clear()
    {
        if (this.Next == null) return;
        Node<T> traversal = this;
        Node<T> old = this;

        
        do
        {
            traversal = traversal.Next;
            old.Next = old;
            old = traversal;

            
        } while (traversal != this);
    }
}