namespace LCS
{
    using System;

    class Program
    {
        private static int[,] lcs;

        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            lcs = new int[s1.Length + 1, s2.Length + 1];
            

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (s1[row - 1] == s2[col - 1])
                    {
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                    }
                }
            }

            Console.WriteLine(lcs[s1.Length, s2.Length]);
        }
    }
}