using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int devider = int.Parse(Console.ReadLine());

            Predicate<int> devide = x => x % devider == 0;

            numbers = Operation(numbers, devide);

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> Operation(List<int> numbers, Predicate<int> devide)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (devide(numbers[i]))
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            List<int> reverse = new List<int>();

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                reverse.Add(numbers[i]);
            }

            return reverse;
        }
    }
}
