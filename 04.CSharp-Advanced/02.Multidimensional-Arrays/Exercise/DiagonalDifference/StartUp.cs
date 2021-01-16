using System;
using System.Linq;

namespace DiagonalDifference
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            //primary
            for (int row = 0; row < n; row++)
            {
                primaryDiagonal += matrix[row, row];
            }

            int secondaryCol = matrix.GetLength(1) - 1;
            //secondary
            for (int row = 0; row < n; row++)
            {
                secondaryDiagonal += matrix[row, secondaryCol];
                secondaryCol--;
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
