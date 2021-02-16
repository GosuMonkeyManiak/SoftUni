using System;
using System.Linq;

namespace RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int fact = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(fact));
        }

        static long Factorial(int factorial)
        {
            if (factorial == 0)
            {
                return 1;
            }

            return factorial * Factorial(factorial - 1);
        }
    }
}
