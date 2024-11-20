using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment;

public class Node<T> : IEnumerable<T>
{
    public T Value { get; }
    public Node<T> Next { get; private set; }
    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public bool Exists(T value)
    {
        Node<T> node = this;
        //This method loop around all the nodes and check if the value exists in the list
        do
        {
            if (EqualityComparer<T>.Default.Equals(node.Value, value))
            {
                return true;
            }
            node = node.Next;
        } while (node != this);
        return false;

    }

    public void Append(T value)
    {
        if (Exists(value))
        {
            throw new InvalidOperationException("Value already exists in the list");
        }

        Node<T> lastNode = this;
        while (lastNode.Next != this)
        {
            lastNode = lastNode.Next;
        }

        Node<T> newNode = new(value);

        //append the new node to the end of the list
        lastNode.Next = newNode;
        newNode.Next = this;
    }

    public void Clear()
    {
        Next = this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> node = this;
        while (node != this)
        {
            yield return node.Value;
            node = node.Next;
        } 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> ChildItems(int max)
    {
        int i = 0;
        Node<T> node = this.Next;
        while (node != this && i < max)
        {
            yield return node.Value;
            node = node.Next;
            i++;
        }
    }
}
