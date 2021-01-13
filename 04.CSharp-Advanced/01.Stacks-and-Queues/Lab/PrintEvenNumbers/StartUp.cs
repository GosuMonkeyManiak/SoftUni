using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> onlyEvenNumbers = new Stack<int>();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] % 2 == 0)
                {
                    onlyEvenNumbers.Push(number[i]);
                }
            }

            Console.WriteLine(string.Join(", ", onlyEvenNumbers));
        }
    }
}
