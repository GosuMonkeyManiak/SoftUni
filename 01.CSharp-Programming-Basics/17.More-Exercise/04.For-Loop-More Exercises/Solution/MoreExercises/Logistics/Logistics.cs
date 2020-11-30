using System;

namespace Logistics
{
    class Logistics
    {
        static void Main(string[] args)
        {
            int countPackage = int.Parse(Console.ReadLine());

            double price = 0;
            double packageTons = 0;
            int microbusTons = 0;
            int truckTons = 0;
            int trainTons = 0;

            for (int i = 0; i < countPackage; i++)
            {
                int tons = int.Parse(Console.ReadLine());
                packageTons += tons;

                if (tons <= 3) //microbus
                {
                    price += tons * 200;
                    microbusTons += tons;
                }
                else if (tons <= 11) //truck
                {
                    price += tons * 175;
                    truckTons += tons;
                }
                else //train
                {
                    price += tons * 120;
                    trainTons += tons;
                }
            }

            double average = price / packageTons;

            Console.WriteLine($"{average:f2}");
            Console.WriteLine($"{microbusTons / packageTons * 100.0:f2}%");
            Console.WriteLine($"{truckTons / packageTons * 100.0:f2}%");
            Console.WriteLine($"{trainTons / packageTons * 100.0:f2}%");
        }
    }
}
