using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(params T[] arr)
        {
            index = 0;
            Create(arr);
        }

        public void Create(params T[] arr)
        {
            if (arr.Length == 0)
            {
                items = new List<T>();
            }
            else
            {
                items = new List<T>(arr);
            }
        }

        public bool Move() => ++index < items.Count;

        public bool HasNext()
        {
            int temp = index + 1;

            return temp < items.Count;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(items[index]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public void PrintAll()
        {
            try
            {
                Console.WriteLine(string.Join(" ", items));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
