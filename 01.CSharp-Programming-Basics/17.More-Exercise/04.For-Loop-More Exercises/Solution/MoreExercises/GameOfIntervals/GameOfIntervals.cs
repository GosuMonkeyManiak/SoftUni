using System;

namespace GameOfIntervals
{
    class GameOfIntervals
    {
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());

            double score = 0.0;
            double firstInterval = 0.0;
            double secondInterval = 0.0;
            double thirdInterval = 0.0;
            double fourthInterval = 0.0;
            double fifthInterval = 0.0;
            double sixthInterval = 0.0;


            for (int i = 0; i < turns; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 0)
                {
                    score /= 2;
                    sixthInterval++;
                }
                else if (num <= 9)
                {
                    score += num * 0.2;
                    firstInterval++;
                }
                else if (num <= 19)
                {
                    score += num * 0.3;
                    secondInterval++;
                }
                else if (num <= 29)
                {
                    score += num * 0.4;
                    thirdInterval++;
                }
                else if (num <= 39)
                {
                    score += 50;
                    fourthInterval++;
                }
                else if (num <= 50)
                {
                    score += 100;
                    fifthInterval++;
                }
                else
                {
                    score /= 2;
                    sixthInterval++;
                }
            }

            Console.WriteLine($"{score:f2}");
            Console.WriteLine($"From 0 to 9: {firstInterval / turns * 100:f2}%");
            Console.WriteLine($"From 10 to 19: {secondInterval / turns * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {thirdInterval / turns * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {fourthInterval / turns * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {fifthInterval / turns * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {sixthInterval / turns * 100:f2}%");

        }
    }
}
