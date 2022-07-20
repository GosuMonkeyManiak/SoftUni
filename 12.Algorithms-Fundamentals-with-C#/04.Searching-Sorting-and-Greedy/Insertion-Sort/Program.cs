namespace Insertion_Sort
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

            InsertionSort(elements);

            Console.WriteLine(string.Join(" ", elements));
        }

        static void InsertionSort(int[] elements)
        {
            for (int i = 1; i < elements.Length; i++)
            {
                int j = i;

                while (j > 0 && elements[j] < elements[j - 1])
                {
                    Swap(elements, j, j - 1);
                    j--;
                }
            }
        }

        static void Swap(int[] elements, int first, int second)
        {
            int temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}