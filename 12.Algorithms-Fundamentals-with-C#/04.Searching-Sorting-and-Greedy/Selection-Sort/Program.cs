namespace Selection_Sort
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

            SelectionSort(elements);

            Console.WriteLine(string.Join(" ", elements));
        }

        static void SelectionSort(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[j] < elements[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Swap(elements, i, min);
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