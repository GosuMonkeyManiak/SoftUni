using System;
using System.Collections.Generic;
using System.Linq;

namespace SumNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            int count = numbers.Count;
            int sum = Sum(numbers);

            Console.WriteLine(count);
            Console.WriteLine(sum);
        }

        static int Sum(List<int> numbers)
        {
            return numbers.Sum();
        }
    }
}
