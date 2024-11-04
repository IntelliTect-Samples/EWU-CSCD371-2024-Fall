public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = this;
    }

    public void Append(T data)
    {
        Node<T> newNode = new Node<T>(data);
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
            if (current.Data.Equals(data))
            {
               return true;
            }
            current = current.Next;
        } while (current != this);
        return false;
    }

    public void Clear()
    {
        Next = null;
    }

    public override string ToString()
    {
       return Data?.ToString() ?? string.Empty;
    }
}