using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> occurs = new SortedDictionary<string, int>();

            List<string> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (string number in numbers)
            {
                if (occurs.ContainsKey(number))
                {
                    occurs[number]++;
                }
                else
                {
                    occurs.Add(number, 1);
                }
            }

            foreach (var item in occurs)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
