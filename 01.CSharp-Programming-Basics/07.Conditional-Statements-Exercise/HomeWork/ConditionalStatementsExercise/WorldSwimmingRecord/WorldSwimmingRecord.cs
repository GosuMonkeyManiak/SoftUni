using System;

namespace WorldSwimmingRecord
{
    class WorldSwimmingRecord
    {
        static void Main(string[] args)
        {
            double worldRecordSeconds = double.Parse(Console.ReadLine());
            double worldRecordMeters = double.Parse(Console.ReadLine());
            double secondForMeterIvan = double.Parse(Console.ReadLine());

            double ivanSecond = worldRecordMeters * secondForMeterIvan;

            double bonusSecond = worldRecordMeters / 15;
            bonusSecond = Math.Floor(bonusSecond);
            bonusSecond *= 12.5;

            ivanSecond += bonusSecond;

            if (ivanSecond < worldRecordSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {ivanSecond:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {ivanSecond - worldRecordSeconds:f2} seconds slower.");
            }
        }
    }
}
