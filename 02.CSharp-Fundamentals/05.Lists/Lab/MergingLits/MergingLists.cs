using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLits
{
    class MergingLists
    {
        static void Main(string[] args)
        {
            List<double> firstNumber = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            List<double> secondNumber = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            List<double> result = new List<double>();

            for (int i = 0; i < Math.Min(firstNumber.Count, secondNumber.Count); i++)
            {
                result.Add(firstNumber[i]);
                result.Add(secondNumber[i]);
            }

            if (firstNumber.Count == secondNumber.Count)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else if (firstNumber.Count > secondNumber.Count)
            {
                RemainingElements(result, secondNumber.Count, firstNumber);
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                RemainingElements(result, firstNumber.Count, secondNumber);
                Console.WriteLine(string.Join(" ", result));
            }
        }

        static void RemainingElements(List<double> result, int smaller, List<double> biggers)
        {

            for (int i = smaller; i < biggers.Count; i++)
            {
                result.Add(biggers[i]);
            }

        }
    }
}
