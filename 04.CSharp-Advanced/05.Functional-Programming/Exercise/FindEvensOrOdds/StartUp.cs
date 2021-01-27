using System;
using System.Collections.Generic;

namespace FindEvensOrOdds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] bound = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int start = int.Parse(bound[0]);
            int end = int.Parse(bound[1]);

            string evenOrOdd = Console.ReadLine();

            Predicate<int> predicate = GetPredicate(evenOrOdd);

            List<int> specialNumbers = GetSpecialNumbers(start, end, predicate);

            Console.WriteLine(string.Join(" ", specialNumbers));
        }

        static List<int> GetSpecialNumbers(int start, int end, Predicate<int> predicate)
        {
            List<int> specialNumbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    specialNumbers.Add(i);
                }
            }

            return specialNumbers;
        }

        static Predicate<int> GetPredicate(string type)
        {
            switch (type)
            {
                case "even": return x => x % 2 == 0;
                case "odd": return x => x % 2 != 0;
                default: return null;
            }
        }
    }
}
