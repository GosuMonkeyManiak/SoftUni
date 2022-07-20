namespace Quick_Sort
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

            QuickSort(elements, 0, elements.Length - 1);

            Console.WriteLine(string.Join(" ", elements));
        }

        static void QuickSort(int[] elements, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int left = start + 1;
            int right = end;

            while (left <= right)
            {
                if (elements[left] > elements[pivot] && elements[right] < elements[pivot])
                {
                    Swap(elements, left, right);
                }

                if (elements[left] <= elements[pivot])
                {
                    left++;
                }

                if (elements[right] >= elements[pivot])
                {
                    right--;
                }
            }

            Swap(elements, pivot, right);

            QuickSort(elements, start, right - 1);
            QuickSort(elements, right + 1, end);
        }

        static void Swap(int[] elements, int first, int second)
        {
            int temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}