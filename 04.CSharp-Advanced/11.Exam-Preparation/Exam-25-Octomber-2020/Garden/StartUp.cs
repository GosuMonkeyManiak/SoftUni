using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            int[,] matrix = new int[n, m];
            List<string> flowerCoordinates = new List<string>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ");
                if (tokens[0] == "Bloom")
                {
                    DoMagic(flowerCoordinates, matrix);
                    break;
                }

                int row = int.Parse(tokens[0]);
                int col = int.Parse(tokens[1]);

                if (!IsValidCoordinate(row, col, n))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                flowerCoordinates.Add($"{tokens[0]} {tokens[1]}");
            }

            Print(matrix);
        }

        static bool IsValidCoordinate(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        static void AllDirection(int row, int col, int[,] matrix)
        {
            //left
            for (int left = col - 1; left >= 0; left--)
            {
                matrix[row, left] += 1;
            }

            for (int right = col + 1; right < matrix.GetLength(1); right++)
            {
                matrix[row, right] += 1;
            }

            for (int up = row - 1; up >= 0; up--)
            {
                matrix[up, col] += 1;
            }

            for (int down = row + 1; down < matrix.GetLength(0); down++)
            {
                matrix[down, col] += 1;
            }
        }

        static void DoMagic(List<string> flowerCoordinate, int[,] matrix)
        {
            for (int i = 0; i < flowerCoordinate.Count; i++)
            {
                string[] tokens = flowerCoordinate[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(tokens[0]);
                int col = int.Parse(tokens[1]);

                matrix[row, col] += 1;

                AllDirection(row, col, matrix);
            }
        }

        static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
