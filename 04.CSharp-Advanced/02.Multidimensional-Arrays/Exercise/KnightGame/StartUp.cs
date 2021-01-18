using System;
using System.Collections.Generic;

namespace KnightGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            for (int row = 0; row < n; row++)
            {
                string elements = Console.ReadLine().ToUpper();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = elements[col].ToString();
                }
            }

            int needToRemove = 0;

            for (int row = 0; row < n; row++)
            {

                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == "K")
                    {
                        List<string> HorizontalPatters = HorizontalPatter(n, row, col); //for one position
                        List<string> VerticalPatters = VerticalPatter(n, row, col); //for one position

                        if (HorizontalPatters.Count == 1 && HorizontalPatters[0] == "all")
                        {
                            needToRemove += RemoveAll(matrix, row, col, "horizon");
                        }
                        else
                        {
                            needToRemove += RemoveSpecific(matrix, row, col, "horizon", HorizontalPatters);
                        }

                        if (VerticalPatters.Count == 1 && VerticalPatters[0] == "all")
                        {
                            needToRemove += RemoveAll(matrix, row, col, "vertical");
                        }
                        else
                        {
                            needToRemove += RemoveSpecific(matrix, row, col, "vertical", VerticalPatters);
                        }

                        HorizontalPatters.Clear();
                        VerticalPatters.Clear();
                    }
                }
            }



            Console.WriteLine(needToRemove);

        }

        static int RemoveSpecific(string[,] matrix, int row, int col, string patter, List<string> available)
        {
            int removed = 0;

            if (patter == "horizon")
            {
                for (int i = 0; i < available.Count; i++)
                {
                    switch (available[i])
                    {
                        case "rightUp":
                            if (matrix[row - 1, col + 2] == "K") //rightUp
                            {
                                removed++;
                                matrix[row - 1, col + 2] = "0";
                            }
                            break;

                        case "rightDown":
                            if (matrix[row + 1, col + 2] == "K") //rightDown
                            {
                                removed++;
                                matrix[row + 1, col + 2] = "0";
                            }
                            break;

                        case "leftUp":
                            if (matrix[row - 1, col - 2] == "K") //leftUp
                            {
                                removed++;
                                matrix[row - 1, col - 2] = "0";
                            }
                            break;

                        case "leftDown":
                            if (matrix[row + 1, col - 2] == "K") //leftDown
                            {
                                removed++;
                                matrix[row + 1, col - 2] = "0";
                            }
                            break;
                    }
                }
            }
            else //vertical
            {
                for (int i = 0; i < available.Count; i++)
                {
                    switch (available[i])
                    {
                        case "UpRight":
                            if (matrix[row - 2, col + 1] == "K") //UpRight
                            {
                                removed++;
                                matrix[row - 2, col + 1] = "0";
                            }
                            break;

                        case "UpLeft":
                            if (matrix[row - 2, col - 1] == "K") //UpLeft
                            {
                                removed++;
                                matrix[row - 2, col - 1] = "0";
                            }
                            break;

                        case "DownRight":
                            if (matrix[row + 2, col + 1] == "K") //DownRight
                            {
                                removed++;
                                matrix[row + 2, col + 1] = "0";
                            }
                            break;

                        case "DownLeft":
                            if (matrix[row + 2, col - 1] == "K") //DownLeft
                            {
                                removed++;
                                matrix[row + 2, col - 1] = "0";
                            }
                            break;
                    }
                }

            }

            return removed;
        }

        static int RemoveAll(string[,] matrix, int row, int col, string patter)
        {
            int removed = 0;

            if (patter == "horizon")
            {
                if (matrix[row - 1, col + 2] == "K") //rightUp
                {
                    removed++;
                    matrix[row - 1, col + 2] = "0";
                }
                if (matrix[row + 1, col + 2] == "K") //rightDown
                {
                    removed++;
                    matrix[row + 1, col + 2] = "0";
                }
                if (matrix[row - 1, col - 2] == "K") //leftUp
                {
                    removed++;
                    matrix[row - 1, col - 2] = "0";
                }
                if (matrix[row + 1, col - 2] == "K") //leftDown
                {
                    removed++;
                    matrix[row + 1, col - 2] = "0";
                }
            }
            else //vertical
            {
                if (matrix[row - 2, col + 1] == "K") //UpRight
                {
                    removed++;
                    matrix[row - 2, col + 1] = "0";
                }
                if (matrix[row - 2, col - 1] == "K") //UpLeft
                {
                    removed++;
                    matrix[row - 2, col - 1] = "0";
                }

                if (matrix[row + 2, col + 1] == "K") //DownRight
                {
                    removed++;
                    matrix[row - 2, col - 1] = "0";
                }
                if (matrix[row + 2, col - 1] == "K") //DownLeft
                {
                    removed++;
                    matrix[row + 2, col - 1] = "0";
                }
            }

            return removed;
        }

        static List<string> HorizontalPatter(int n, int row, int col) // for one position
        {
            List<string> whichIsCorrect = new List<string>();

            bool rightCaseUp = (col + 2 >= 0 && col + 2 < n) &&
                               (row - 1 >= 0 && row - 1 < n);

            bool rightCaseDown = (col + 2 >= 0 && col + 2 < n) &&
                                 (row + 1 >= 0 && row + 1 < n);

            bool leftCaseUp = (col - 2 >= 0 && col - 2 < n) &&
                              (row - 1 >= 0 && row - 1 < n);

            bool leftCaseDown = (col - 2 >= 0 && col - 2 < n) &&
                                (row + 1 >= 0 && row + 1 < n);

            if (rightCaseUp && rightCaseDown && leftCaseUp && leftCaseDown)
            {
                return new List<string>() { "all" };
            }

            if (rightCaseUp)
            {
                whichIsCorrect.Add("rightUp");
            }
            if (rightCaseDown)
            {
                whichIsCorrect.Add("rightDown");
            }
            if (leftCaseUp)
            {
                whichIsCorrect.Add("leftUp");
            }
            if (leftCaseDown)
            {
                whichIsCorrect.Add("leftDown");
            }

            return whichIsCorrect;
        }

        static List<string> VerticalPatter(int n, int row, int col) //for one position
        {
            List<string> whichIsCorrect = new List<string>();

            bool upCaseRight = (row + 2 >= 0 && row + 2 < n) &&
                               (col + 1 >= 0 && col + 1 < n);

            bool upCaseLeft = (row + 2 >= 0 && row + 2 < n) &&
                              (col - 1 >= 0 && col - 1 < n);

            bool downCaseRight = (row - 2 >= 0 && row - 2 < n) &&
                                 (col + 1 >= 0 && col + 1 < n);

            bool downCaseLeft = (row - 2 >= 0 && row - 2 < n) &&
                                (col - 1 >= 0 && col - 1 < n);

            if (upCaseRight && upCaseLeft && downCaseRight && downCaseLeft)
            {
                return new List<string>() { "all" };
            }

            if (upCaseRight)
            {
                whichIsCorrect.Add("UpRight");
            }
            if (upCaseLeft)
            {
                whichIsCorrect.Add("UpLeft");
            }
            if (downCaseRight)
            {
                whichIsCorrect.Add("DownRight");
            }
            if (downCaseLeft)
            {
                whichIsCorrect.Add("DownLeft");
            }

            return whichIsCorrect;
        }
    }
}
