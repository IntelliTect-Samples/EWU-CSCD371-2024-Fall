namespace GenericsHomework;

public class Node<T>
{
    public T Data { get; }
    public Node<T> Next { get; private set; }

    public Node(T data)
    {
        Data = data;
        Next = this;
    }

    public void Append(T data)
    {
        Node<T> newNode = new(data);
        if(Exists(data))
        {
            throw new InvalidOperationException("Data already exists in the list");
        }
        if (Next == null)
        {
            Next = newNode;
            newNode.Next = this;
        }
        else
        {
            Node<T> current = Next;
            while (current.Next != this)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Next = this;
        }
    }
    public bool Exists(T data)
    {
        Node<T> current = this;
        do
        {
            if (current.Data == null && data == null || current!.Data!.Equals(data))
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
        while (current != this)
        {
            Node<T> temp = current;
            current = current.Next;      // we should not worry about Garbage Collection because the reference to the next node is removed, so the node will be collected. 
            temp.Next = temp;            // the list is circular, so we can assign the next node to itself to remove the reference. 
        }                                // then we can assign the next node to this to make the list circular again.
        this.Next = this;
    }

    public override string ToString()
    {
       return Data?.ToString() ?? string.Empty;
    }
}