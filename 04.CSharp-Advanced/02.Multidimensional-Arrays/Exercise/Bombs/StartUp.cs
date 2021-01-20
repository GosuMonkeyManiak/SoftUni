using System;
using System.Linq;

namespace Bombs
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

            string[] allCoordinate = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allCoordinate.Length; i++)
            {
                string[] eachCoordinate = allCoordinate[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(eachCoordinate[0]);
                int col = int.Parse(eachCoordinate[1]);

                if (matrix[row, col] <= 0)
                {
                    continue;
                }

                Explode(matrix, row, col);

            }

            int aliveCells = 0;
            int sumOfAliceCells = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sumOfAliceCells += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfAliceCells}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Explode(int[,] matrix, int row, int col)
        {
            //8 cases

            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0)) //up
            {
                if (!(matrix[row - 1, col] <= 0))
                {
                    matrix[row - 1, col] -= matrix[row, col];
                }

            }

            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0)) //down
            {
                if (!(matrix[row + 1, col] <= 0))
                {
                    matrix[row + 1, col] -= matrix[row, col];
                }
                
            }

            if (col - 1 >= 0 && col - 1 < matrix.GetLength(1)) //left
            {
                if (!(matrix[row, col - 1] <= 0))
                {
                    matrix[row, col - 1] -= matrix[row, col];
                }
                
            }

            if (col + 1 >= 0 && col + 1 < matrix.GetLength(1)) //right
            {
                if (!(matrix[row, col + 1] <= 0))
                {
                    matrix[row, col + 1] -= matrix[row, col];
                }
                
            }

            //diagonals

            if ((row - 1 >= 0 && row - 1 < matrix.GetLength(0)) && (col - 1 >= 0 && col - 1 < matrix.GetLength(1))) //top left
            {
                if (!(matrix[row - 1, col - 1] <= 0))
                {
                    matrix[row - 1, col - 1] -= matrix[row, col];
                }
                
            }

            if ((row - 1 >= 0 && row - 1 < matrix.GetLength(0)) && (col + 1 >= 0 && col + 1 < matrix.GetLength(1))) //top right
            {
                if (!(matrix[row - 1, col + 1] <= 0))
                {
                    matrix[row - 1, col + 1] -= matrix[row, col];
                }
                
            }

            if ((row + 1 >= 0 && row + 1 < matrix.GetLength(0)) && (col - 1 >= 0 && col - 1 < matrix.GetLength(1))) //bottom left
            {
                if (!(matrix[row + 1, col - 1] <= 0))
                {
                    matrix[row + 1, col - 1] -= matrix[row, col];
                }
                
            }

            if ((row + 1 >= 0 && row + 1 < matrix.GetLength(0)) && (col + 1 >= 0 && col + 1 < matrix.GetLength(1))) //bottom right
            {
                if (!(matrix[row + 1, col + 1] <= 0))
                {
                    matrix[row + 1, col + 1] -= matrix[row, col];
                }
                
            }

            matrix[row, col] = 0; //reduce the bomb
        }
    }
}
