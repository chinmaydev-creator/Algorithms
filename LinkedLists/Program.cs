// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, to world of LinkedLists!");
var linkedList = new MyLinkedList();
linkedList.AddAtHead(1);
linkedList.AddAtTail(3);
linkedList.AddAtIndex(1, 2);

// linkedList.AddAtHead(245);
// linkedList.AddAtHead(0);
// linkedList.AddAtHead(76);
// linkedList.AddAtTail(34);
// linkedList.AddAtHead(22);
// linkedList.AddAtIndex(3, 56);
linkedList.DeleteAtIndex(1);

int index = 0;
Console.WriteLine("Value returned from linkedList: ");
Console.Write("[");
while (linkedList.Get(index) != -1)
{
    Console.Write($"{linkedList.Get(index)}, ");
    index++;
}
Console.Write("]");

public class MyLinkedList
{

    internal Node? head = null;
    public MyLinkedList()
    {

    }

    public int Get(int index)
    {
        int currIndex = 0;
        Node? currNode = head;

        if (currNode == null)
        {
            return -1;
        }
        else
        {
            while (currIndex != index)
            {
                if (currNode.next != null)
                {
                    currNode = currNode.next;
                    currIndex++;
                }
                else
                {
                    return -1;
                }
            }
            return currNode.val;
        }

    }

    public void AddAtHead(int val)
    {
        if (head != null)
        {
            Node currHead = head;
            head = new Node();
            head.val = val;
            head.next = currHead;
        }
        else
        {
            head = new Node();
            head.val = val;
        }
    }

    public void AddAtTail(int val)
    {
        if (head != null)
        {
            Node currNode = head;
            while (currNode.next != null)
            {
                currNode = currNode.next;
            }
            currNode.next = new Node();
            currNode.next.val = val;
        }
        else
        {
            head = new Node();
            head.val = val;
        }
    }

    public void AddAtIndex(int index, int val)
    {
        Node currNode = head;
        if (index == 0)
        {
            AddAtHead(val);
        }
        else
        {
            int currIndex = 0;
            while (currIndex + 1 != index)
            {
                if (currNode == null)
                {
                    return;
                }
                else
                {
                    currNode = currNode.next;
                    currIndex++;
                }
            }
            if (currNode.next != null)
            {
                var tempNode = DeepCopy(currNode.next);
                currNode.next = new Node();
                currNode.next.val = val;
                currNode.next.next = tempNode;
            }
            else
            {
                currNode.next = new Node();
                currNode.next.val = val;
            }
        }
    }

    public void DeleteAtIndex(int index)
    {
        if (index == 0)
        {
            if (head != null)
            {
                head = head.next;
            }
        }
        else
        {
            int currIndex = 0;
            Node currNode = head;
            while (currIndex + 1 != index)
            {
                if (currNode == null)
                {
                    return;
                }
                else
                {
                    currNode = currNode.next;
                    currIndex++;
                }
            }
            if (currNode.next != null)
            {
                currNode.next = currNode.next.next;
            }
        }

    }
    internal Node DeepCopy(Node node)
    {
        return new Node { val = node.val, next = node.next };
    }
    internal class Node
    {
        internal int val;
        internal Node? next;

    }
}


/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */