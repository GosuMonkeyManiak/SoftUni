using System;

namespace BonusScore
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());

            double bonusScore = 0;

            if (score <= 100)
            {
                bonusScore += 5;
            }
            else if (score > 1000)
            {
                double bonus = score * 0.10;
                bonusScore += bonus;

            }
            else
            {
                double bonus = score * 0.20;
                bonusScore += bonus;
            }

            if (score % 2 == 0)
            {
                bonusScore++;
            }

            if (score % 10 == 5)
            {
                bonusScore += 2;
            }

            Console.WriteLine(bonusScore);
            Console.WriteLine(score + bonusScore);
        }
    }
}
