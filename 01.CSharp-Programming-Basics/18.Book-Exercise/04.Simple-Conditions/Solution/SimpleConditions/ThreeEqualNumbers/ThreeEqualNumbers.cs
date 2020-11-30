using System;

namespace ThreeEqualNumbers
{
    class ThreeEqualNumbers
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if ((num1 == num2 && num1 == num3) && (num2 == num1 && num2 == num3) && (num3 == num1 && num3 == num2))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
