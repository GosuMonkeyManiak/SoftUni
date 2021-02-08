using System;
using System.Collections.Generic;

namespace GenericList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>(7);

            list.Add(1);
            list.Add(36);
            list.Add(42);
            list.Add(50);
            list.Add(60);
            list.Add(100);
            list.Add(99);

            list.RemoveAt(3);
            
            Console.WriteLine(list.Contains(99));

            list.Insert(0, 0);

            list.Swap(0, list.Count);

        }
    }
}
