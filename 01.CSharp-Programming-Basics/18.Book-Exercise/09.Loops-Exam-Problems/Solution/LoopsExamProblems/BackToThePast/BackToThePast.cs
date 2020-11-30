using System;

namespace BackToThePast
{
    class BackToThePast
    {
        static void Main(string[] args)
        {
            double inheMoney = double.Parse(Console.ReadLine());
            int yearHaveToLive = int.Parse(Console.ReadLine());

            int age = 18;

            for (int i = 1800; i <= yearHaveToLive; i++)
            {
                if (i % 2 == 0)
                {
                    inheMoney -= 12000;
                }
                else
                {
                    inheMoney -= 12000 + 50 * age;
                }

                age++;
            }

            if (inheMoney >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {inheMoney:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(inheMoney):f2} dollars to survive.");
            }
        }
    }
}
