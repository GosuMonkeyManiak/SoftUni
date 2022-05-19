namespace RecursiveFactorial
{
    using System;

    public class Program
    {
        public static ulong Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            var factorial = (ulong)n * Factorial(n - 1);

            return factorial;
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var factorial = Factorial(n);

            Console.WriteLine(factorial);
        }
    }
}