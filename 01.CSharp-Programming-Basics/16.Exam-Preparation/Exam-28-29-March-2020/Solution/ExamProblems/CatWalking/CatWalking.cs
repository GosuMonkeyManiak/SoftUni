using System;

namespace CatWalking
{
    class CatWalking
    {
        static void Main(string[] args)
        {
            int minutsWalkingPerDay = int.Parse(Console.ReadLine());//minuts
            int walkingPerDay = int.Parse(Console.ReadLine());//perDay
            int calPerDay = int.Parse(Console.ReadLine());//cal per day

            int burnCalPerWalk = minutsWalkingPerDay * 5;
            int burnCalPerDay = burnCalPerWalk * walkingPerDay; //all burn

            double burnNeeded = calPerDay * 0.50;

            if (burnCalPerDay >= (int)(burnNeeded))
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnCalPerDay}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnCalPerDay}.");
            }
        }
    }
}
