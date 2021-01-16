using System;

namespace PascalTriangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] pascal = new long[n][];

            for (int row = 0; row < n; row++)
            {
                pascal[row] = new long[row + 1];

                for (int col = 0; col < pascal[row].Length; col++)
                {
                    long sum = 0;

                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        sum += pascal[row - 1][col - 1];   
                    }

                    if (row - 1 >= 0 && col < row)
                    {
                        sum += pascal[row - 1][col];
                    }


                    if (sum == 0)
                    {
                        pascal[row][col] = 1;
                    }
                    else
                    {
                        pascal[row][col] = sum;
                    }

                }

            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write(pascal[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
