using System;

namespace Snake
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int snakeRow = 0;
            int snakeCol = 0;

            int firstBorrowRow = 0;
            int firstBorrwoCol = 0;

            int secondBorrowRow = 0;
            int secondBorrowCol = 0;

            bool isFirst = true;

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    if (rowData[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (rowData[col] == 'B' && isFirst)
                    {
                        firstBorrowRow = row;
                        firstBorrwoCol = col;
                        isFirst = false;
                    }

                    if (rowData[col] == 'B' && !isFirst)
                    {
                        secondBorrowRow = row;
                        secondBorrowCol = col;
                    }

                    matrix[row, col] = rowData[col];
                }
            }


            int eatenFood = 0;

            while (eatenFood < 10)
            {
                string command = Console.ReadLine();

                matrix[snakeRow, snakeCol] = '.';

                snakeRow = MoveRow(command, snakeRow);
                snakeCol = MoveCol(command, snakeCol);

                if (IsValidCoordinate(snakeRow, snakeCol, size) == false)
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {eatenFood}");
                    Print(matrix);
                    return;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    eatenFood++;
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

                    if (snakeRow == firstBorrowRow && snakeCol == firstBorrwoCol)
                    {
                        snakeRow = secondBorrowRow;
                        snakeCol = secondBorrowCol;
                    }
                    else
                    {
                        snakeRow = firstBorrowRow;
                        snakeCol = firstBorrwoCol;
                    }
                }

                matrix[snakeRow, snakeCol] = 'S';
            }


            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {eatenFood}");

            Print(matrix);
        }

        static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col].ToString());
                }
                Console.WriteLine();
            }
        }

        static int MoveRow(string command, int row)
        {
            if (command == "up")
            {
                row--;
            }
            else if (command == "down")
            {
                row++;
            }

            return row;
        }

        static int MoveCol(string command, int col)
        {
            if (command == "left")
            {
                col--;
            }
            else if (command == "right")
            {
                col++;
            }

            return col;
        }

        static bool IsValidCoordinate(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

    }
}
