using System;

namespace GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable
    {
        public Box(T element)
        {
            Value = element;
        }

        public T Value { get; set; }
    }
}
