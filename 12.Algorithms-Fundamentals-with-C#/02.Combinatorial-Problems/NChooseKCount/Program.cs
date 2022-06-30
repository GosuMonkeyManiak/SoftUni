namespace NChooseKCount
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(Pascal(n, k));
        }

        static long Pascal(int row, int col)
        {
            if (row <= 1 || col == 0 || row == col)
            {
                return 1;
            }

            return Pascal(row - 1, col) + Pascal(row - 1, col - 1);
        }
    }
}