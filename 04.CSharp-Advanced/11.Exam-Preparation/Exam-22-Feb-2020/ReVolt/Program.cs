using System;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    if (rowData[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    matrix[row, col] = rowData[col];
                }
            }

            bool isWon = false;

            matrix[playerRow, playerCol] = '-';

            for (int i = 0; i < c; i++)
            {
                string movement = Console.ReadLine();

                playerRow = MoveRow(movement, playerRow);
                playerCol = MoveCol(movement, playerCol);

                if (!IsValidCoordinates(playerRow, playerCol, n))
                {
                    playerRow = ChangeRow(playerRow, n);
                    playerCol = ChangeCol(playerCol, n);
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow = MoveRow(movement, playerRow);
                    playerCol = MoveCol(movement, playerCol);

                    if (!IsValidCoordinates(playerRow, playerCol, n))
                    {
                        playerRow = ChangeRow(playerRow, n);
                        playerCol = ChangeCol(playerCol, n);
                    }
                }
                else if (matrix[playerRow, playerCol] == 'T')
                {
                    movement = ChangeDirection(movement);
                    playerRow = MoveRow(movement, playerRow);
                    playerCol = MoveCol(movement, playerCol);

                    if (!IsValidCoordinates(playerRow, playerCol, n))
                    {
                        playerRow = ChangeRow(playerRow, n);
                        playerCol = ChangeCol(playerCol, n);
                    }
                }
                else if (matrix[playerRow, playerCol] == 'F')
                {
                    isWon = true;
                    matrix[playerRow, playerCol] = 'f';
                    break;
                }

                if (i == c - 1)
                {
                    matrix[playerRow, playerCol] = 'f';
                }
            }


            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            Print(matrix);
        }

        static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static string ChangeDirection(string movement)
        {
            if (movement == "up")
            {
                return "down";
            }
            else if (movement == "down")
            {
                return "up";
            }
            else if (movement == "left")
            {
                return "right";
            }
            else
            {
                return "left";
            }
        }

        static int ChangeCol(int col, int n)
        {
            if (col >= n)
            {
                return 0;
            }

            if (col < 0)
            {
                return n - 1;
            }

            return col;
        }

        static int ChangeRow(int row, int n)
        {
            if (row >= n)
            {
                return 0;
            }

            if (row < 0)
            {
                return n - 1;
            }

            return row;
        }

        static bool IsValidCoordinates(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        static int MoveCol(string movement, int col)
        {
            if (movement == "left")
            {
                col--;
            }

            if (movement == "right")
            {
                col++;
            }

            return col;
        }

        static int MoveRow(string movement, int row)
        {
            if (movement == "up")
            {
                row--;
            }

            if (movement == "down")
            {
                row++;
            }

            return row;
        }
    }
}
