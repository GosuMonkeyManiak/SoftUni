namespace Binary_Search
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

            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(elements, target));
        }

        static int BinarySearch(int[] elements, int target)
        {
            int left = 0;
            int right = elements.Length - 1;
            int mid;

            while (left <= right)
            {
                mid = (left + right) / 2;

                if (target == elements[mid])
                {
                    return mid;
                }

                if (target > elements[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}