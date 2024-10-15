using System;

class Node
{
    public int data;
    public Node next;
    public Node(int data)
    {
        this.data = data;
        this.next = null;
    }
}

class Program
{
    static void Main()
    {
        Node head = new Node(1);
        head.next = new Node(2);
        head.next.next = new Node(3);
        head.next.next.next = head;  // Creating a cycle

        bool hasCycle = DetectCycle(head);
        Console.WriteLine($"Cycle detected: {hasCycle}");
    }

    static bool DetectCycle(Node head)
    {
        Node slow = head, fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }
        return false;
    }
}
