using System;

namespace FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            long first = Factorial(firstNumber);
            long second = Factorial(secondNumber);

            double result = first * 1.0 / second;

            Console.WriteLine($"{result:f2}");
        }

        static long Factorial(int number)
        {
            long result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= (long)i;
            }

            return result;
        }
    }
}
