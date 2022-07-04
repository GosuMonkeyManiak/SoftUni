namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static char[,] matrix;
        private static bool[,] viseted;
        private static int count;
        private static List<Area> areas;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            viseted = new bool[rows, cols];
            areas = new List<Area>();

            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            FindAreas(0, 0, false, true);

            areas = areas
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.StartRow)
                .ThenBy(a => a.StartCol)
                .ToList();

            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({areas[i].StartRow}, {areas[i].StartCol}), size: {areas[i].Count}");
            }
        }

        static void FindAreas(int row, int col, bool isLoopStart, bool firstCall)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (!firstCall)
            {
                if (matrix[row, col] == '*' || viseted[row, col] == true)
                {
                    return;
                }
            }

            if (row == 0 && col == 0 && !isLoopStart)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (!viseted[i, j] && matrix[i, j] != '*')
                        {
                            viseted[i, j] = true;
                            count = 1;

                            FindAreas(i - 1, j, true, false); //up
                            FindAreas(i + 1, j, true, false); //down
                            FindAreas(i, j - 1, true, false); //left
                            FindAreas(i, j + 1, true, false); //right

                            areas.Add(new Area(i, j, count));
                        }
                    }
                }
            }
            else
            {
                viseted[row, col] = true;

                count++;

                FindAreas(row - 1, col, true, false); //up
                FindAreas(row + 1, col, true, false); //down
                FindAreas(row, col - 1, true, false); //left
                FindAreas(row, col + 1, true, false); //right
            }
        }
    }

    class Area
    {
        public Area(int startRow, int startCol, int count)
        {
            this.StartRow = startRow;
            this.StartCol = startCol;
            this.Count = count;
        }

        public int StartRow { get; set; }

        public int StartCol { get; set; }

        public int Count { get; set; }
    }
}