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
        Node<T> newNode = new Node<T>(data);
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
    
    
    
    


}