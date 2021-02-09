using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable<T>
    {
        public Box(T element)
        {
            this.Element = element;
        }

        public T Element { get; set; }
    }
}
