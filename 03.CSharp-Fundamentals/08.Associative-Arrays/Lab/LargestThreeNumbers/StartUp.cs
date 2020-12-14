using System;
using System.Linq;
using System.Collections.Generic;

namespace LargestThreeNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToList();

            if (numbers.Count <= 3)
            {
                Console.WriteLine(string.Join(' ', numbers));
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
