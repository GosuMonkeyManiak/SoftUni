using System;
using System.Linq;

namespace EqualArrays
{
    class EqualArrays
    {
        static void Main(string[] args)
        {
            int[] firstNumbers = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondNumbers = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int sum = 0;

            for (int i = 0; i < firstNumbers.Length; i++)
            {
                if (firstNumbers[i] != secondNumbers[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
                sum += firstNumbers[i];
            }

            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
