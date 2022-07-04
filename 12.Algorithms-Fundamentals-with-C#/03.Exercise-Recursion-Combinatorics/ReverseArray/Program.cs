namespace ReverseArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int[] numbers;
        private static List<int> reverseNumbers;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            reverseNumbers = new List<int>();

            Reverse(0);

            Console.WriteLine(string.Join(" ", reverseNumbers));
        }

        static void Reverse(int index)
        {
            if (index >= numbers.Length - 1)
            {
                reverseNumbers.Add(numbers[index]);
                return;
            }

            Reverse(index + 1);

            reverseNumbers.Add(numbers[index]);
        }
    }
}