using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T> where T : struct
    {
        public T Item { get; set; }

        public Box(T element)
        {
            Item = element;
        }

        public override string ToString()
        {
            return $"{Item.GetType()}: {Item}";
        }
    }
}
