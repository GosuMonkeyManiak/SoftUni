using System;

namespace MountainRun
{
    class MountainRun
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secondForOneMeter = double.Parse(Console.ReadLine());

            double reachInSeconds = meters * secondForOneMeter;
            double slow = Math.Floor(meters / 50) * 30;
            reachInSeconds += slow;

            if (reachInSeconds < recordSeconds)
            {
                Console.WriteLine($"Yes! The new record is {reachInSeconds:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {reachInSeconds - recordSeconds:f2} seconds slower.");
            }
        }
    }
}
