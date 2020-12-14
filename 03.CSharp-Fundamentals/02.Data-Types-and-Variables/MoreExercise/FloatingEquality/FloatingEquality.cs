using System;

namespace FloatingEquality
{
    class FloatingEquality
    {
        static void Main(string[] args)
        {
            decimal num1 = decimal.Parse(Console.ReadLine());
            decimal num2 = decimal.Parse(Console.ReadLine());

            decimal presicionLevel = 0.000001M;

            if (Math.Abs(num1 - num2) >= presicionLevel)
            {
                Console.WriteLine(false);
            }
            else
            {
                Console.WriteLine(true);
            }
        }
    }
}
