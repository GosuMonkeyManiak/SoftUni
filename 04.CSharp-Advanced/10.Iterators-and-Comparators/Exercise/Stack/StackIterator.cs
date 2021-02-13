using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class StackIterator<T> : IEnumerator<T>
    {
        private List<T> items;
        private int index;

        public StackIterator(IEnumerable<T> element)
        {
            Reset();
            items = new List<T>(element);
        }

        public T Current => items[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            return ++index < items.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
