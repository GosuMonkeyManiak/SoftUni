using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private Stack<T> items;

        public MyStack()
        {
            items = new Stack<T>();
        }

        public void Push(params T[] element)
        {
            foreach (var item in element)
            {
                items.Push(item);
            }
        }

        public void Pop()
        {
            try
            {
                items.Pop();
            }
            catch (Exception)
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackIterator<T>(items);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
