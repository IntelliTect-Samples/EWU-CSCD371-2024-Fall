using System;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GenericsHomework;

public class Node<T>
{
    // Only used for the first node in a list, the rest will be added using the Append method
    public Node(T data)
    {
        this.Data = data;
        this.Next = this;   // Next points to itself
    }
    public T Data { get; }

    // The Next property should be non-nullable(careful to follow the non-nullable property guidelines) ❌✔
    public Node<T> Next { get; private set; }

    // Add an Append method that takes a value and appends a new Node instance after the current
    // node(by invoking the Next property). ❌✔
    // The current node is the last node added
    public void Append(T newData)
    {
        // Throw an error on attempt to append a duplicate value
        if (Exists(newData))
        {
            throw new ArgumentException("Value already exists in the list");
        }

        var addedNode = new Node<T>(newData);
        Node<T> cur = this;
       
        while(cur.Next != this)
        {
            cur = cur.Next;
        }
        cur.Next = addedNode;
        addedNode.Next = this;
        
    }

    private bool Exists(T newData)
    {
        // Cycle through the list to check if the value already exists
        Node<T> current = this;
        do
        {
            if (current.Data!.Equals(newData))
            {
                return true;
            }
            current = current.Next;
        } while (current != this);
        return false;
    }

    public void Clear()
    {
        var current = this;

        // Cycling through the list to set each node's Next property to itself (except the current node),
        // this way we don't need to worry about garbage collection
        while (current.Next != this)
        {
            var temp = current.Next;
            current.Next = current.Next.Next;
            temp.Next = temp;
        }

        this.Next = this;
    }

    public override string ToString()
    {
        return "Data: " + Data;
    }

}
