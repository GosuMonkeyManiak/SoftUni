using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                int[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = new int[elements.Length];

                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row][col] = elements[col];
                }
            }

            while (true)
            {
                string[] spllited = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (spllited[0] == "END")
                {
                    break;
                }

                int row = int.Parse(spllited[1]);
                int col = int.Parse(spllited[2]);
                int value = int.Parse(spllited[3]);

                if (spllited[0] == "Add" && ((row >= 0 && row < n) && (col >= 0 && col < n)) )
                {
                    matrix[row][col] += value;
                }
                else if (spllited[0] == "Subtract" && ((row >= 0 && row < n) && (col >= 0 && col < n)) )
                {
                    matrix[row][col] -= value;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }


            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
