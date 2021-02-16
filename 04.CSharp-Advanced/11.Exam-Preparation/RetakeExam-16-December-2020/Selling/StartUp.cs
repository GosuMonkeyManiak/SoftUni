using System;

namespace Selling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;

            bool isFirst = true;

            int firstPillarRow = 0;
            int firstPillarCol = 0;

            int secondPillarRow = 0;
            int secondPillarCol = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    if (rowData[col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (rowData[col] == 'O' && isFirst)
                    {
                        isFirst = false;
                        firstPillarRow = row;
                        firstPillarCol = col;
                    }

                    if (rowData[col] == 'O' && !isFirst)
                    {
                        secondPillarRow = row;
                        secondPillarCol = col;
                    }

                    matrix[row, col] = rowData[col];
                }
            }

            //run out of bakery => out from matrix
            //at least 50 dollar
            int money = 0;

            while (money < 50)
            {
                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                playerRow = MoveRow(command, playerRow);
                playerCol = MoveCol(command, playerCol);

                if (!IsInside(playerRow, playerCol, n))
                {
                    break;
                }

                if (matrix[playerRow, playerCol] == 'O')
                {
                    matrix[playerRow, playerCol] = '-';

                    if (playerRow == firstPillarRow && playerCol == firstPillarCol)
                    {
                        playerRow = secondPillarRow;
                        playerCol = secondPillarCol;
                    }
                    else
                    {
                        playerRow = firstPillarRow;
                        playerCol = firstPillarCol;
                    }

                    matrix[playerRow, playerCol] = '-';
                }
                else if (char.IsDigit(matrix[playerRow, playerCol])) //digit
                {
                    money += int.Parse(matrix[playerRow, playerCol].ToString());
                }


                matrix[playerRow, playerCol] = 'S';

            }

            if (money >= 50)
            {
                Console.WriteLine($"Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine($"Bad news, you are out of the bakery.");
            }

            Console.WriteLine($"Money: {money}");

            Print(matrix);
        }

        static int MoveRow(string command, int playerRow) //up and down
        {
            if (command == "up")
            {
                playerRow--;
            }
            else if (command == "down")
            {
                playerRow++;
            }

            return playerRow;
        }

        static int MoveCol(string commnad, int playerCol) //left and right
        {
            if (commnad == "left")
            {
                playerCol--;
            }
            else if (commnad == "right")
            {
                playerCol++;
            }

            return playerCol;
        }

        static bool IsInside(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        static void Print(char[,] arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(0); col++)
                {
                    Console.Write($"{arr[row, col]}");
                }
                
                Console.WriteLine();
            }
        }
    }
}
