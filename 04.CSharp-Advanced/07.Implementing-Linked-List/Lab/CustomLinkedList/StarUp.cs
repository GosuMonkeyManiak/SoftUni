using System;

namespace CustomLinkedList
{
    class StarUP
    {
        static void Main(string[] args)
        {
            CustomLinkedList linkedList = new CustomLinkedList();
            linkedList.AddLast(0);
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            int[] array = linkedList.ToArray();

            linkedList.ForEach(x => Console.WriteLine(x));
        }
    }
}
