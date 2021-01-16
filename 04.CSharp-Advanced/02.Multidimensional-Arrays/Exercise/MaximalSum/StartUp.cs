using System;
using System.Linq;

namespace MaximalSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] sizeOfMatrix = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizeOfMatrix[0];
            int cols = sizeOfMatrix[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int rowCoordinate = -1;
            int colCoordinate = -1;
            int max = int.MinValue;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = 0;

                    sum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                           matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                           matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > max)
                    {
                        max = sum;
                        rowCoordinate = row;
                        colCoordinate = col;
                    }
                }
            }


            Console.WriteLine($"Sum = {max}");

            for (int row = rowCoordinate; row < rowCoordinate + 3; row++)
            {
                for (int col = colCoordinate; col < colCoordinate + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
