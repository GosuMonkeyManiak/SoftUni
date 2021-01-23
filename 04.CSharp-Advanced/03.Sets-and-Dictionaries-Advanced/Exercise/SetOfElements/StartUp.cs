using System;
using System.Collections.Generic;
using System.Linq;

namespace SetOfElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] lenghtOfSets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = lenghtOfSets[0];
            int m = lenghtOfSets[1];

            HashSet<double> firstSet = new HashSet<double>();
            HashSet<double> secondSet = new HashSet<double>();
            HashSet<double> result = new HashSet<double>();

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                firstSet.Add(number);
            }

            for (int i = 0; i < m; i++)
            {
                double number = double.Parse(Console.ReadLine());

                secondSet.Add(number);
            }

            result = firstSet.Intersect(secondSet).ToHashSet();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
