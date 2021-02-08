using System;
using System.Collections.Generic;
using System.Text;

namespace GenericList
{
    class CustomList<T>
    {
        private const int InitialCapacity = 2;
        private T[] items;

        public CustomList()
        {
            this.items = new T[InitialCapacity];
        }
        public CustomList(int initialCapacity)
        {
            this.items = new T[initialCapacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get 
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.items[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[Count] = element;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            T element = this.items[index];
            this.items[index] = default;
            this.Count--;
            Shift(index);

            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }

            return element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.items.Length == this.Count)
            {
                Resize();
            }

            ShiftToRight(index);
            this.items[index] = element;
            this.Count++;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex > this.Count - 1 && 
                secondIndex < 0 || secondIndex > this.Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            T element = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = element;
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
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

        private void Shift(int removeAt)
        {
            for (int i = removeAt; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1]; 
            }
        }

        private void Shrink()
        {
            T[] copy = new T[this.items.Length / 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
    }
}
