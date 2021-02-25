using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GenericStack
{
    class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public CustomStack()
        {
            this.items = new T[InitialCapacity];
        }
        public CustomStack(int initialCapacity)
        {
            this.items = new T[initialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Count--;
            T element = this.items[this.Count];
            this.items[this.Count] = default;

            return element;
        }

        public T Peek()
        {
            if (this.Count <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.items[this.Count - 1];
        }

        private void Resize()
        {
            T[] copy = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
