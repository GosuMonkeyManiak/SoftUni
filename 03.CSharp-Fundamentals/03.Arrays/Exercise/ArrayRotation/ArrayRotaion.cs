using System;
using System.Linq;

namespace ArrayRotation
{
    class ArrayRotaion
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int numbersOfRotaion = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfRotaion; i++)
            {
                int firstElement = numbers[0];

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }
                numbers[numbers.Length - 1] = firstElement;
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
