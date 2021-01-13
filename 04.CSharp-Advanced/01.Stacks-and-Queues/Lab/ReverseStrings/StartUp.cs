using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string inPut = Console.ReadLine();

            Stack<char> reverseString = new Stack<char>();

            for (int i = 0; i < inPut.Length; i++)
            {
                reverseString.Push(inPut[i]);
            }

            while (reverseString.Count > 0)
            {
                Console.Write(reverseString.Pop());
            }
        }
    }
}
