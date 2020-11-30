using System;
using System.Linq;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int eachSideNumbers = numbers.Length / 4;

            int[,] result = new int[2, eachSideNumbers * 2];

            int[] firstRow = new int[eachSideNumbers * 2];
            int[] secondRow = new int[numbers.Length - (eachSideNumbers * 2)];

            int count = 0;

            for (int i = eachSideNumbers - 1; i >= 0; i--)
            {
                firstRow[count] = numbers[i];
                count++;
            }
            for (int i = numbers.Length - 1; i >= numbers.Length - eachSideNumbers; i--)
            {
                firstRow[count] = numbers[i];
                count++;
            }

            count = 0;

            for (int i = eachSideNumbers; i < numbers.Length - eachSideNumbers; i++)
            {
                secondRow[count] = numbers[i];
                count++;
            }

            for (int rows = 0; rows < 2; rows++)
            {
                for (int col = 0; col < eachSideNumbers * 2; col++)
                {
                    if (rows == 0)
                    {
                        result[rows, col] = firstRow[col];
                    }
                    else
                    {
                        result[rows, col] = secondRow[col];
                    }
                }   
            }

            
            for (int col = 0; col < eachSideNumbers * 2; col++)
            {
                int sum = result[0, col] + result[1, col];
                Console.Write($"{sum} ");
            }
        }
    }
}
