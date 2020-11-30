using System;
using System.Linq;

namespace ReverseString
{
    class String
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            for (int i = word.Length - 1; i >= 0; i--)
            {
                Console.Write(word[i]);
            }
        }
    }
}
