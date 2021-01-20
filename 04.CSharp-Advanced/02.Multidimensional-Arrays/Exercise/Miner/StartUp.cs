using System;
using System.Linq;

namespace Miner
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            string[] moves = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int allCoals = 0;
            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < n; row++)
            {
                string inPut = Console.ReadLine().Replace(" ", "");

                char[] elements = inPut.ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    if (elements[col] == 'c')
                    {
                        allCoals++;
                    }

                    if (elements[col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }

                    field[row, col] = elements[col];
                }
            }

            int collectCoal = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                string currentMove = moves[i];

                bool canGoThere = false;

                switch (currentMove)
                {
                    case "left":
                        canGoThere = CanGoThere(startRow, startCol, "left", n);
                        if (!canGoThere)
                        {
                            continue;
                        }

                        startCol -= 1;
                        if (field[startRow, startCol] == 'c')
                        {
                            collectCoal++;
                            field[startRow, startCol] = '*';

                            if (collectCoal == allCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }

                        if (field[startRow, startCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            return;
                        }

                        break;

                    case "right":
                        canGoThere = CanGoThere(startRow, startCol, "right", n);
                        if (!canGoThere)
                        {
                            continue;
                        }

                        startCol += 1;
                        if (field[startRow, startCol] == 'c')
                        {
                            collectCoal++;
                            field[startRow, startCol] = '*';

                            if (collectCoal == allCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }

                        if (field[startRow, startCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            return;
                        }

                        break;

                    case "up":
                        canGoThere = CanGoThere(startRow, startCol, "up", n);
                        if (!canGoThere)
                        {
                            continue;
                        }

                        startRow -= 1;
                        if (field[startRow, startCol] == 'c')
                        {
                            collectCoal++;
                            field[startRow, startCol] = '*';

                            if (collectCoal == allCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }

                        if (field[startRow, startCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            return;
                        }

                        break;

                    case "down":
                        canGoThere = CanGoThere(startRow, startCol, "down", n);
                        if (!canGoThere)
                        {
                            continue;
                        }

                        startRow += 1;
                        if (field[startRow, startCol] == 'c')
                        {
                            collectCoal++;
                            field[startRow, startCol] = '*';

                            if (collectCoal == allCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                return;
                            }
                        }

                        if (field[startRow, startCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol})");
                            return;
                        }

                        break;  
                }


            }

            Console.WriteLine($"{allCoals - collectCoal} coals left. ({startRow}, {startCol})");
        }

        static bool CanGoThere(int startRow, int startCol, string direction, int n)
        {
            if (direction == "left")
            {
                if (startCol - 1 >= 0 && startCol - 1 < n)
                {
                    return true;
                }

            }
            else if (direction == "right")
            {
                if (startCol + 1 >= 0 && startCol + 1 < n)
                {
                    return true;
                }
            }
            else if (direction == "up")
            {
                if (startRow - 1 >= 0 && startRow - 1 < n)
                {
                    return true;
                }
            }
            else //down
            {
                if (startRow + 1 >= 0 && startRow + 1 < n)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
