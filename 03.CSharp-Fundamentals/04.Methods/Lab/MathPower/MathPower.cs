using System;

namespace MathPower
{
    class MathPower
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = Multiply(number, power);
            Console.WriteLine(result);
        }

        public static double Multiply(double number, double power)
        {
            double result = Math.Pow(number, power);

            return result;
        }
    }
}
