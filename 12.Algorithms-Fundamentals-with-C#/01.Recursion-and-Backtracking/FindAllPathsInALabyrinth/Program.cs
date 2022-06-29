namespace FindAllPathsInALabyrinth
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            char[,] lab = new char[n, m];

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < m; col++)
                {
                    lab[row, col] = line[col];
                }
            }

            FindAllPaths(lab, 0, 0, new List<string>(), string.Empty);
        }

        public static void FindAllPaths(char[,] lab, int row, int col, List<string> directions, string direction)
        {
            if (row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1))
            {
                return;
            }

            if (lab[row, col] == '*' || lab[row, col] == 'v')
            {
                return;
            }
            
            directions.Add(direction);

            if (lab[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            lab[row, col] = 'v';

            FindAllPaths(lab, row - 1, col, directions, "U"); //Up
            FindAllPaths(lab, row + 1, col, directions, "D"); //Down
            FindAllPaths(lab, row, col - 1, directions, "L"); //Left
            FindAllPaths(lab, row, col + 1, directions, "R"); //Right

            lab[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}