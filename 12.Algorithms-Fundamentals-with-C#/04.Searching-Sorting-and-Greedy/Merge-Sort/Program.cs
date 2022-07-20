namespace Merge_Sort
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] result = MergeSort(elements);

            Console.WriteLine(string.Join(" ", result));
        }

        static int[] MergeSort(int[] elements)
        {
            if (elements.Length == 1)
            {
                return elements;
            }

            int mid = elements.Length / 2;
            int[] left = elements.Take(mid).ToArray();
            int[] right = elements.Skip(mid).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        static int[] Merge(int[] leftElements, int[] rightElements)
        {
            int[] result = new int[leftElements.Length + rightElements.Length];
            int resultIndex = 0;

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < leftElements.Length && rightIndex < rightElements.Length)
            {
                if (leftElements[leftIndex] <= rightElements[rightIndex])
                {   
                    result[resultIndex] = leftElements[leftIndex];
                    leftIndex++;
                    resultIndex++;
                }
                else
                {   
                    result[resultIndex] = rightElements[rightIndex];
                    rightIndex++;
                    resultIndex++;
                }
            }

            for (int i = leftIndex; i < leftElements.Length; i++)
            {
                result[resultIndex] = leftElements[i];
                resultIndex++;
            }

            for (int i = rightIndex; i < rightElements.Length; i++)
            {
                result[resultIndex] = rightElements[i];
                resultIndex++;
            }

            return result;
        }
    }
}