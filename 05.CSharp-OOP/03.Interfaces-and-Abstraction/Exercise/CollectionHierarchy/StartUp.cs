using System;
using System.Collections.Generic;
using CollectionHierarchy.Contract;
using CollectionHierarchy.Model;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            string[] items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int numberOfRemove = int.Parse(Console.ReadLine());

            List<int> indexes = new List<int>();

            for (int i = 0; i < items.Length; i++)
            {
                indexes.Add(addCollection.Add(items[i]));
            }

            Console.WriteLine(string.Join(' ', indexes));
            indexes = new List<int>();

            for (int i = 0; i < items.Length; i++)
            {
                indexes.Add(addRemoveCollection.Add(items[i]));
            }

            Console.WriteLine(string.Join(' ', indexes));
            indexes = new List<int>();

            for (int i = 0; i < items.Length; i++)
            {
                indexes.Add(myList.Add(items[i]));
            }

            Console.WriteLine(string.Join(' ', indexes));

            //removing

            List<string> removedItems = new List<string>();

            for (int i = 0; i < numberOfRemove; i++)
            {
                removedItems.Add(addRemoveCollection.Remove());
            }

            Console.WriteLine(string.Join(' ', removedItems));
            removedItems = new List<string>();

            for (int i = 0; i < numberOfRemove; i++)
            {
                removedItems.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(' ', removedItems));
        }
    }
}
