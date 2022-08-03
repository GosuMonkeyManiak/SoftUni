namespace TheTyrant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static int minSum(int[] arr, int n)
        {
            int[] dp = new int[n];
            
            if (n == 1)
                return arr[0];
            
            if (n == 2)
                return Math.Min(arr[0], arr[1]);

            if (n == 3)
                return Math.Min(arr[0], Math.Min(arr[1], arr[2]));

            if (n == 4)
                return Math.Min(Math.Min(arr[0], arr[1]),
                                Math.Min(arr[2], arr[3]));

            dp[0] = arr[0];
            dp[1] = arr[1];
            dp[2] = arr[2];
            dp[3] = arr[3];

            for (int i = 4; i < n; i++)
                dp[i] = arr[i] + Math.Min(Math.Min(dp[i - 1], dp[i - 2]),
                                 Math.Min(dp[i - 3], dp[i - 4]));

            return Math.Min(Math.Min(dp[n - 1], dp[n - 2]),
                            Math.Min(dp[n - 4], dp[n - 3]));
        }

        static public void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = arr.Length;

            Console.WriteLine(minSum(arr, n));
        }

    }
}