namespace TribonacciSquence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write(Tribonacci(i) + " ");
            }
        }

        static int Tribonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            if (n == 3)
            {
                return 2;
            }

            return Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
        }
    }
}
