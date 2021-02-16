using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            list.AddFirst("Pesho");
            list.AddLast("Gosho");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
