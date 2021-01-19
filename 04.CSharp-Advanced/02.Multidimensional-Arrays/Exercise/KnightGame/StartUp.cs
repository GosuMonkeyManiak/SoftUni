using System;
using System.Collections.Generic;

namespace KnightGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string elements = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    board[row, col] = elements[col];
                }
            }

            int replace = 0;
            int killerRow = 0;
            int killerCol = 0;

            while (true)
            {
                int maxAttack = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int currentAttack = GetAttack(row, col, board, n);

                            if (currentAttack > maxAttack)
                            {
                                maxAttack = currentAttack;
                                killerRow = row;
                                killerCol = col;
                            }
                        }
                    }
                }


                if (maxAttack > 0)
                {
                    board[killerRow, killerCol] = '0';
                    replace++;
                }
                else
                {
                    Console.WriteLine(replace);
                    break;
                }
            }



        }

        static int GetAttack(int row, int col, char[,] board, int n)
        {
            int attack = 0;

            if (((row - 2 >= 0 && row - 2 < n) && (col + 1 >= 0 && col + 1 < n)) && board[row - 2, col + 1] == 'K')
            {
                attack++;
            }

            if (((row - 2 >= 0 && row - 2 < n) && (col - 1 >= 0 && col - 1 < n)) && board[row - 2, col - 1] == 'K') //Up
            {
                attack++;
            }

            if (((row + 2 >= 0 && row + 2 < n) && (col + 1 >= 0 && col + 1 < n)) && board[row + 2, col + 1] == 'K')
            {
                attack++;
            }

            if (((row + 2 >= 0 && row + 2 < n) && (col - 1 >= 0 && col - 1 < n)) && board[row + 2, col - 1] == 'K') //Down
            {
                attack++;
            }

            if (((row + 1 >= 0 && row + 1 < n) && (col + 2 >= 0 && col + 2 < n)) && board[row + 1, col + 2] == 'K')
            {
                attack++;
            }

            if (((row - 1 >= 0 && row - 1 < n) && (col + 2 >= 0 && col + 2 < n)) && board[row - 1, col + 2] == 'K') // Left
            {
                attack++;
            }

            if (((row + 1 >= 0 && row + 1 < n) && (col - 2 >= 0 && col - 2 < n)) && board[row + 1, col - 2] == 'K')
            {
                attack++;
            }

            if (((row - 1 >= 0 && row - 1 < n) && (col - 2 >= 0 && col - 2 < n)) && board[row - 1, col - 2] == 'K') //right
            {
                attack++;
            }

            return attack;
        }
    }
}
