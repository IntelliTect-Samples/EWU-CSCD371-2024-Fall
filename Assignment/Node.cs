using System.Collections;

namespace Assignment;

public class Node<T> : IEnumerable<T>
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
            current = current.Next;      
            temp.Next = temp;            
        }                              
        this.Next = this;
    }

    public override string ToString()
    {
       return Data?.ToString() ?? string.Empty;
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = this;
        Node<T> head = this;
        do
        {
            yield return current.Data;
            current = current.Next;
        } while (current != this);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public IEnumerable<T> ChildItems(int num)
    {
        int count = 0;
        Node<T> current = this;
        Node<T> head = this;
        do
        {
            yield return current.Data;
            current = current.Next;
            count++;
        } while (current != head && count < num);
    }
}
