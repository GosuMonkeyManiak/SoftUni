using System;

namespace BonusScore
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double bonusScore = 0;

            if (num <= 100)
            {
                bonusScore += 5;
            }
            if (num > 1000)
            {
                bonusScore += num * 0.1;
            }
            else if (num > 100)
            {
                bonusScore += num * 0.2;
            }

            if (num % 2 == 0)
            {
                bonusScore += 1;
            }

            if (num % 10 == 5)
            {
                bonusScore += 2;
            }

            Console.WriteLine($"{bonusScore}");
            Console.WriteLine($"{num + bonusScore}");
        }
    }
}
