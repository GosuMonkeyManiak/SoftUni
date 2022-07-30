namespace Fibonacci
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Dictionary<ulong, ulong> cache;

        static void Main(string[] args)
        {
            cache = new Dictionary<ulong, ulong>();

            ulong n = ulong.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(n));
        }

        static ulong Fibonacci(ulong n)
        {
            if (n <= 1)
            {
                return n;
            }

            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            ulong result = Fibonacci(n - 1) + Fibonacci(n - 2);

            cache[n] = result;

            return result;
        }
    }
}