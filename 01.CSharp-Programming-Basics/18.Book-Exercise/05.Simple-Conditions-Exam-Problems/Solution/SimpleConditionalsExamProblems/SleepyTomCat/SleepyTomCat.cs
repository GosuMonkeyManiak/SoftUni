using System;

namespace SleepyTomCat
{
    class SleepyTomCat
    {
        static void Main(string[] args)
        {
            int restDay = int.Parse(Console.ReadLine());

            int workDay = 365 - restDay;

            int timeForPlay = (workDay * 63) + (restDay * 127);

            if (timeForPlay <= 30000)
            {
                Console.WriteLine("Tom sleeps well");
                int temp = 30000 - timeForPlay;
                Console.WriteLine($"{temp / 60} hours and {temp % 60} minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                int temp = timeForPlay - 30000;
                Console.WriteLine($"{temp / 60} hours and {temp % 60} minutes more for play");
            }
        }
    }
}
