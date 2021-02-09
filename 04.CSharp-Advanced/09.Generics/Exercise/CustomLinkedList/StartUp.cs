using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(0);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);

            linkedList.RemoveLast();
            linkedList.RemoveFirst();

            linkedList.ForEach(x => Console.WriteLine(x));
        }
    }
}
