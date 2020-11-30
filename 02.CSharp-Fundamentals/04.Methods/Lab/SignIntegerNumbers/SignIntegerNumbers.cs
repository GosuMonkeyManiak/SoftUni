using System;

namespace SignIntegerNumbers
{
    class SignIntegerNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintSign(number);
        }

        static void PrintSign(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }
    }
}
