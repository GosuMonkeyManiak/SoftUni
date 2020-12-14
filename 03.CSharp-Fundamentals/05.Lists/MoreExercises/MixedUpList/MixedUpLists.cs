using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpList
{
    class MixedUpLists
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> mixedList = new List<int>();

            int last = 0;
            int previus = 0;

            if (firstNumbers.Count > secondNumbers.Count)
            {
                last = firstNumbers[firstNumbers.Count - 1];
                previus = firstNumbers[firstNumbers.Count - 2];

                firstNumbers.Remove(last);
                firstNumbers.Remove(previus);
            }
            else
            {
                last = secondNumbers[0];
                previus = secondNumbers[1];

                secondNumbers.Remove(last);
                secondNumbers.Remove(previus);

                secondNumbers.Reverse();
            }

            for (int i = 0; i < firstNumbers.Count; i++)
            {
                mixedList.Add(firstNumbers[i]);
            }

            for (int i = 0; i < secondNumbers.Count; i++)
            {
                mixedList.Add(secondNumbers[i]);
            }

            List<int> result = new List<int>();

            int bigger = 0;
            int smaller = 0;

            if (last > previus)
            {
                bigger = last;
                smaller = previus;
            }
            else
            {
                bigger = previus;
                smaller = last;
            }

            for (int i = 0; i < mixedList.Count; i++)
            {
                if (mixedList[i] < bigger && mixedList[i] > smaller)
                {
                    result.Add(mixedList[i]);
                }
            }

            result.Sort();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
