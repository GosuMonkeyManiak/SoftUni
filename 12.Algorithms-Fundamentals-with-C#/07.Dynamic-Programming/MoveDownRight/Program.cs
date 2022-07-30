namespace MoveDownRight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int[,] matrix;
        private static int[,] dp;

        private static List<KeyValuePair<int, int>> path;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            matrix = new int[n, m];
            dp = new int[n, m];
            path = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < n; i++)
            {
                int[] lineNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < lineNumbers.Length; j++)
                {
                    matrix[i, j] = lineNumbers[j];
                }
            }

            dp[0, 0] = matrix[0, 0];

            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                dp[0, i] = matrix[0, i] + dp[0, i - 1];
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                dp[i, 0] = matrix[i, 0] + dp[i - 1, 0];
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    int maxOfLeftOrUp = Math.Max(dp[row, col - 1], dp[row - 1, col]);

                    dp[row, col] = maxOfLeftOrUp + matrix[row, col];
                }
            }

            RecoverPath();
            path.Reverse();

            Console.WriteLine(string.Join(" ", path.Select(kvp => $"[{kvp.Key}, {kvp.Value}]")));
        }

        static void RecoverPath()
        {
            int row = dp.GetLength(0) - 1;
            int col = dp.GetLength(1) - 1;

            while (row >= 0 && col >= 0)
            {
                path.Add(new KeyValuePair<int, int>(row, col));

                //left  row col - 1
                //up row - 1 col

                int leftElement = -1;
                int upElement = -1;

                if (CanGoThere(row, col - 1)) //left
                {
                    leftElement = dp[row, col - 1];
                }

                if (CanGoThere(row - 1, col)) // up
                {
                    upElement = dp[row - 1, col];
                }

                if (leftElement == -1)
                {
                    row--;
                    continue;
                }

                if (upElement == -1)
                {
                    col--;
                    continue;
                }

                if (leftElement >= upElement)
                {
                    col--;
                } 
                else
                {
                    row--;
                }
            }
        }

        static bool CanGoThere(int row, int col)
            => row >= 0 && row < dp.GetLength(0) && col >= 0 && col < dp.GetLength(1);
    }
}