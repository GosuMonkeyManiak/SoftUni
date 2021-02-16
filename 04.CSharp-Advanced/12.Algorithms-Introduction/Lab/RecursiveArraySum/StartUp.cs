using System;
using System.Linq;

namespace RecursiveArraySum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(array, 0));
        }

        static int Sum(int[] arr, int startIndex)
        {
            if (startIndex == arr.Length)
            {
                return 0;
            }

            return arr[startIndex] + Sum(arr, startIndex + 1);
        }
    }
}
