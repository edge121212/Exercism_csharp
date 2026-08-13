public class Deque<T>
{
    private class Node
    {
        public T Value;
        public Node Next;
        public Node Prev;

        public Node(T Value)
        {
            this.Value = Value;
        }
    }

    private Node head;
    private Node tail;
    
    public void Push(T value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
    }

    public T Pop()
    {
        T valueToReturn = tail.Value;
        if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail = tail.Prev;
            tail.Next = null;
        }
        return valueToReturn;
    }

    public void Unshift(T value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            head.Prev = newNode;
            newNode.Next = head;
            head = newNode;
        }
    }

    public T Shift()
    {
        T valueToReturn = head.Value;
        if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            head = head.Next;
            head.Prev = null;
        }
        return valueToReturn;
    }
}