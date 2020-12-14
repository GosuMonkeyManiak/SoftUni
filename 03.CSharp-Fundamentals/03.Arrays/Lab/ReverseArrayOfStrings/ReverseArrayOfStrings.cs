using System;
using System.Linq;

namespace ReverseArrayOfStrings
{
    class ReverseArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] someString = Console.ReadLine().Split();

            someString = someString.Reverse().ToArray();

            Console.WriteLine(string.Join(" ",someString));
        }
    }
}
