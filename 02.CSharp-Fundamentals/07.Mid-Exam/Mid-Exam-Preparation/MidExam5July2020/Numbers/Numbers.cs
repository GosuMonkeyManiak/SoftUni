using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Numbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double average = numbers.Average();

            List<int> greaterByAverage = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    greaterByAverage.Add(numbers[i]);
                }
            }

            greaterByAverage = greaterByAverage.OrderByDescending(x => x).ToList();

            if (greaterByAverage.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (greaterByAverage.Count >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{greaterByAverage[i]} ");
                }
            }
            else
            {
                for (int i = 0; i < greaterByAverage.Count; i++)
                {
                    Console.Write($"{greaterByAverage[i]} ");
                }
            }
        }
    }
}
