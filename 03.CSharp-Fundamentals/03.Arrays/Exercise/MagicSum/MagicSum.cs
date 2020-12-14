using System;
using System.Linq;

namespace MagicSum
{
    class MagicSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int magicSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == magicSum)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                    }
                }
            }
        }
    }
}
