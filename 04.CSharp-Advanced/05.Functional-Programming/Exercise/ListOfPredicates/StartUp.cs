using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int, bool> func = (x, y) => x % y == 0;

            List<int> numbers = GetNumberWhichDivide(n, dividers, func);

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> GetNumberWhichDivide(int n, List<int> dividers, Func<int, int, bool> condition)
        {
            List<int> dividedNumber = new List<int>();
            bool isDivide = true;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < dividers.Count; j++)
                {
                    if (!condition(i, dividers[j]))
                    {
                        isDivide = false;
                        break;
                    }
                }

                if (isDivide)
                {
                    dividedNumber.Add(i);
                }

                isDivide = true;
            }

            return dividedNumber;
        }
    }
}
