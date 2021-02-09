using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T> where T : class
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
