using System;
using System.Linq;

namespace SquaresInMatrix
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

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int equalsMatrix = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    bool isEqual = matrix[row, col] == matrix[row, col + 1] &&
                                   matrix[row, col] == matrix[row + 1, col + 1] &&
                                   matrix[row, col] == matrix[row + 1, col];

                    if (isEqual)
                    {
                        equalsMatrix++;
                    }
                }
            }

            Console.WriteLine(equalsMatrix);
        }
    }
}
