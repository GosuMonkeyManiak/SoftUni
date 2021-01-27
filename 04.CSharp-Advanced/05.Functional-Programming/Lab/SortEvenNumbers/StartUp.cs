using System;
using System.Collections.Generic;
using System.Linq;

namespace SortEvenNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> inPut = InPut();
            List<int> evenNumbers = GetEvenNumbers(inPut, x => x % 2 == 0);

            Console.WriteLine(string.Join(", ", evenNumbers));
        }

        static List<int> GetEvenNumbers(List<int> numbers, Func<int, bool> condition)
        {
            List<int> evenNumber = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (condition(numbers[i]))
                {
                    evenNumber.Add(numbers[i]);
                }
            }

            return evenNumber.OrderBy(x => x).ToList();
        }

        static List<int> InPut()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
