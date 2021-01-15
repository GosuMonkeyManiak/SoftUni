using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] squareMatrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    squareMatrix[row, col] = elements[col];
                }
            }

            int primaryDiagonal = 0;

            for (int row = 0; row < n; row += 1)
            {
                int col = row;

                primaryDiagonal += squareMatrix[row, col];

            }

            Console.WriteLine(primaryDiagonal);
        }
    }
}
