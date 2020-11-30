using System;

namespace WaterOverFlow
{
    class WaterOverFlow
    {
        static void Main(string[] args)
        {
            //water wank with capacity 255 lites
            byte n = byte.Parse(Console.ReadLine());

            byte watertank = 0;

            for (int i = 0; i < n; i++)
            {
                ushort liters = ushort.Parse(Console.ReadLine());
                if (watertank + liters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                watertank += (byte)liters;
            }

            Console.WriteLine(watertank);
        }
    }
}
