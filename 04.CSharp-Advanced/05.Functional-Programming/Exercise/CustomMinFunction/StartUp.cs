using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> min = GeMin;

            int minVAlue = min(number);

            Console.WriteLine(minVAlue);
        }

        static int GeMin(List<int> numbers)
        {
            int min = int.MaxValue;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }
    }
}
