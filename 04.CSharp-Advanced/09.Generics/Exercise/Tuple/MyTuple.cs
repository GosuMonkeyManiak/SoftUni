using System;

namespace Tuple
{
    public class MyTuple<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public MyTuple(T1 firstElement, T2 secondElement)
        {
            Item1 = firstElement;
            Item2 = secondElement;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
