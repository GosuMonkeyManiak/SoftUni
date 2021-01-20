using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimensionals = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensionals[0];
            int cols = dimensionals[1];

            char[,] field = new char[rows, cols];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = rowData[col];

                    if (rowData[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            bool isWon = false;
            bool isDied = false;

            foreach (char direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                if (direction == 'U')
                {
                    newPlayerRow--;
                }
                else if (direction == 'D')
                {
                    newPlayerRow++;
                }
                else if (direction == 'L')
                {
                    newPlayerCol--;
                }
                else if (direction == 'R')
                {
                    newPlayerCol++;
                }

                if (!IsValidCoorcinate(newPlayerRow, newPlayerCol, rows, cols))
                {
                    isWon = true;
                    field[playerRow, playerCol] = '.';
                    //spread bunnies
                    List<int[]> bunniesCoordinates = GetBunniesCoordinate(field);
                    SpreadBunnies(bunniesCoordinates, field);
                }
                else if (field[newPlayerRow, newPlayerCol] == '.')
                {
                    field[playerRow, playerCol] = '.';
                    field[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                    //spread bunnies
                    List<int[]> bunniesCoordinates = GetBunniesCoordinate(field);
                    SpreadBunnies(bunniesCoordinates, field);

                    if (field[playerRow, playerCol] == 'B')
                    {
                        isDied = true;
                    }
                }
                else if (field[newPlayerRow, newPlayerCol] == 'B')
                {
                    field[playerRow, playerCol] = '.';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                    isDied = true;
                    //spread bunnies
                    List<int[]> bunniesCoordinates = GetBunniesCoordinate(field);
                    SpreadBunnies(bunniesCoordinates, field);
                }

                if (isWon || isDied)
                {
                    break;
                }

            }

            Print(field);

            string result = "";

            if (isWon)
            {
                result += "won";
            }
            else
            {
                result += "dead";
            }

            result += $": {playerRow} {playerCol}";

            Console.WriteLine(result);

        }

        private static void Print(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row , col]);
                }

                Console.WriteLine();
            }
        }

        private static void SpreadBunnies(List<int[]> bunniesCoordinates, char[,] field)
        {
            foreach (int[] coordinate in bunniesCoordinates)
            {
                int row = coordinate[0];
                int col = coordinate[1];

                SpreadBunny(row - 1, col, field);
                SpreadBunny(row + 1, col, field);
                SpreadBunny(row, col - 1, field);
                SpreadBunny(row, col + 1, field);
            }
        }

        private static void SpreadBunny(int row, int col, char[,] field)
        {
            if (IsValidCoorcinate(row, col, field.GetLength(0), field.GetLength(1)))
            {
                field[row, col] = 'B';
            }
        }

        private static List<int[]> GetBunniesCoordinate(char[,] field)
        {
            List<int[]> bunniesCoordinate = new List<int[]>();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'B')
                    {
                        bunniesCoordinate.Add(new int[] { row, col });
                    }
                }
            }

            return bunniesCoordinate;
        }

        private static bool IsValidCoorcinate(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
