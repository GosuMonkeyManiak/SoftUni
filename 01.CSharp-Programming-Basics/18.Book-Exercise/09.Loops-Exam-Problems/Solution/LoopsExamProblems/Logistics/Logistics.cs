using System;

namespace Logistics
{
    class Logistics
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int microBus = 0;
            int truck = 0;
            int train = 0;

            int microBusTons = 0;
            int trucksTons = 0;
            int trainTons = 0;

            int allTons = 0;

            for (int i = 0; i < n; i++)
            {
                int packageTons = int.Parse(Console.ReadLine());

                if (packageTons <= 3)
                {
                    microBus++;
                    microBusTons += packageTons;
                }
                else if (packageTons <= 11)
                {
                    truck++;
                    trucksTons += packageTons;
                }
                else
                {
                    train++;
                    trainTons += packageTons;
                }
            }

            allTons += microBusTons + trucksTons + trainTons;

            Console.WriteLine($"{1.0 * (microBusTons * 200 + trucksTons * 175 + trainTons * 120) / allTons:f2}");
            Console.WriteLine($"{1.0 * microBusTons / allTons * 100:f2}%");
            Console.WriteLine($"{1.0 * trucksTons / allTons * 100:f2}%");
            Console.WriteLine($"{1.0 * trainTons / allTons * 100:f2}%");
        }
    }
}
