namespace _8QueensPuzzle
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        public static HashSet<int> attackedRows = new HashSet<int>();
        public static HashSet<int> attackedCols = new HashSet<int>();
        public static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        public static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            bool[,] board = new bool[8, 8];

            EightQueens(board, 0);
        }

        public static void EightQueens(bool[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPutQueen(row, col)) //can put a queen
                {
                    board[row, col] = true;

                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonals.Add(row - col);
                    attackedRightDiagonals.Add(col + row);

                    EightQueens(board, row + 1);

                    board[row, col] = false;

                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonals.Remove(row - col);
                    attackedRightDiagonals.Remove(col + row);
                }
            }
        }

        public static bool CanPutQueen(int row, int col)
        {
            return !attackedRows.Contains(row) &&
                   !attackedCols.Contains(col) &&
                   !attackedLeftDiagonals.Contains(row - col) &&
                   !attackedRightDiagonals.Contains(col + row);
        }

        public static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}