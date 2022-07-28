namespace AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static string[,] matrix;
        private static bool[,] visited;
        private static Dictionary<string, int> numbersOfArea;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(n, m);
            visited = new bool[n, m];
            numbersOfArea = new Dictionary<string, int>();

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (!visited[row, col])
                    {
                        string searchChar = matrix[row, col];
                        FindArea(row, col, searchChar);

                        if (!numbersOfArea.ContainsKey(searchChar))
                        {
                            numbersOfArea.Add(searchChar, 0);
                        }

                        numbersOfArea[searchChar]++;
                    }
                }
            }

            Console.WriteLine($"Areas: {numbersOfArea.Sum(x => x.Value)}");

            foreach (var (key, value) in numbersOfArea.OrderBy(x => x.Key))
            {
                Console.WriteLine($"Letter '{key}' -> {value}");
            }
        }

        static void FindArea(int row, int col, string searchChar)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (matrix[row, col] != searchChar)
            {
                return;
            }

            visited[row, col] = true;

            FindArea(row - 1, col, searchChar); //up
            FindArea(row + 1, col, searchChar); //right
            FindArea(row, col - 1, searchChar); //left
            FindArea(row, col + 1, searchChar); //down
        }

        static string[,] ReadMatrix(int n, int m)
        {
            string[,] matrix = new string[n, m];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = line[j].ToString();
                }
            }

            return matrix;
        }
    }
}