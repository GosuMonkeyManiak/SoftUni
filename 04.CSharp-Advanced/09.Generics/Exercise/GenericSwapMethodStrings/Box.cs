using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
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
