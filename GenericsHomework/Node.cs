using System.Text;

namespace GenericsHomework;

public class Node<T>
{
    public T Data { get; private set; }
    private Node<T> _next;
    
    public Node<T> Next
    {
        get => _next; 
        set => _next = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Node(T data)
    {
        Data = data;
        _next = this;
    }
    
    public void Append(T data)
    {
        if (Exists(data))
        {
            throw new ArgumentException("Data already exists in the list");
        }
        
        Node<T> newNode = new (data);
        Node<T> current = this;

        if (current.Next == this)
        {
            current.Next = newNode;
            newNode.Next = this;
        }
        else
        {
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
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        } while (current != this);

        return false;
    }
    
    public override string ToString()
    {
        Node<T> current = this;
        StringBuilder sb = new();
        
        do
        {
            sb.Append(current.Data);
            sb.Append(" -> ");
            current = current.Next;
        } while (current != this);
        
        return sb.ToString();
    }

    public void Clear()
    {
        Node<T> current = Next;
        Node<T> temp;
        
        while (current != this)
        {
            temp = current.Next;
            current.Next = current;
            current = temp;
        }

        Next = this;
    }
}
