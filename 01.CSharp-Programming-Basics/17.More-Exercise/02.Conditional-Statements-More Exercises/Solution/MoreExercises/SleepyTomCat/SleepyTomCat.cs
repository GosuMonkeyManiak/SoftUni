using System;

namespace SleepyTomCat
{
    class SleepyTomCat
    {
        static void Main(string[] args)
        {
            //input rest day
            int restDays = int.Parse(Console.ReadLine());

            //one year 365
            //calculate work day
            int workDay = 365 - restDays;
            //calculate time play with cat
            int timePlay = workDay * 63 + restDays * 127;

            //if time > 30 000 tom wiil run away
            //else Tom sleeps well

            if (timePlay <= 30000)
            {
                double time = 30000 - timePlay;

                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{Math.Floor(time / 60)} hours and {Math.Floor(time % 60)} minutes less for play");
            }
            else
            {
                double time = timePlay - 30000;
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{Math.Floor(time / 60)} hours and {Math.Floor(time % 60)} minutes more for play");
            }
        }
    }
}
