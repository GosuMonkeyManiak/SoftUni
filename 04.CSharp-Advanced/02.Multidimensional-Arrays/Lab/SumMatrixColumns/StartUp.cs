using System;
using System.Linq;

namespace SumMatrixColumns
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] sizeOfMatrix = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizeOfMatrix[0];
            int cols = sizeOfMatrix[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int sumOfColumn = 0;
                for (int row = 0; row < rows; row++)
                {
                    sumOfColumn += matrix[row, col];
                }

                Console.WriteLine(sumOfColumn);
            }
        }
    }
}
