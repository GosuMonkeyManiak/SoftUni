namespace LongestIncreasingSubsqeuence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] lengthOfLIS = new int[elements.Length];
            int[] prev = new int[elements.Length];

            for (int k = 0; k < lengthOfLIS.Length; k++)
            {
                lengthOfLIS[k] = 1;
            }

            int i = 0;
            int j = 1;


            while (i < elements.Length - 1 && j < elements.Length)
            {
                if (i == j)
                {
                    i = 0;
                    j++;
                    continue;
                }
                else if (elements[i] < elements[j])
                {
                    if (lengthOfLIS[i] + 1 > lengthOfLIS[j])
                    {
                        lengthOfLIS[j] = lengthOfLIS[i] + 1;
                        prev[j] = i;
                    }
                }

                i++;
            }

            int firstBiggestValueIndex = 0;
            int max = int.MinValue;

            for (int k = 0; k < lengthOfLIS.Length; k++)
            {
                if (lengthOfLIS[k] > max)
                {
                    max = lengthOfLIS[k];
                    firstBiggestValueIndex = k;
                }
            }

            List<int> finalValues = new List<int>();

            int currentIndex = firstBiggestValueIndex;
            int elementCount = max;
            int currentElementCount = 0;

            while (currentIndex >= 0)
            {
                finalValues.Add(elements[currentIndex]);
                currentIndex = prev[currentIndex];
                currentElementCount++;

                if (currentElementCount == elementCount)
                {
                    break;
                }
            }

            finalValues = finalValues
                .OrderBy(c => c)
                .ToList();

            Console.WriteLine(string.Join(" ", finalValues));
        }
    }
}
