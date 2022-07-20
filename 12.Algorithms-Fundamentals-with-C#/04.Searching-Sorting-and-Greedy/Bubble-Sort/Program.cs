namespace Bubble_Sort
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

            BubbleSort(elements);

            Console.WriteLine(string.Join(" ", elements));
        }

        static void BubbleSort(int[] elements)
        {
            bool isSorted = false;
            int sortedElements = 0;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 1; i < elements.Length - sortedElements; i++)
                {
                    if (elements[i - 1] > elements[i])
                    {
                        Swap(elements, i - 1, i);
                        isSorted = false;
                    }
                }

                sortedElements++;
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