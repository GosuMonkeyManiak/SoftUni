using System;

namespace CarToGo
{
    class CarToGo
    {
        static void Main(string[] args)
        {
            //inPut
            double buget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            //two seasons Summer and Winter
            //two type cars Cabrio Jeep
            //three class Economy class Compact class Luxury class

            string classCar = "";
            string typeCar = "";
            double carPrice = 0.0;

            if (buget  <= 100)
            {
                classCar = "Economy class";

                if (season == "Summer")
                {
                    typeCar = "Cabrio";
                    carPrice = buget * 0.35;
                }
                else
                {
                    typeCar = "Jeep";
                    carPrice = buget * 0.65;
                }
            }
            else if (buget <= 500)
            {
                classCar = "Compact class";

                if (season == "Summer")
                {
                    typeCar = "Cabrio";
                    carPrice = buget * 0.45;
                }
                else
                {
                    typeCar = "Jeep";
                    carPrice = buget * 0.80;
                }
            }
            else
            {
                classCar = "Luxury class";
                typeCar = "Jeep";
                carPrice = buget * 0.90;
            }

            Console.WriteLine($"{classCar}");
            Console.WriteLine($"{typeCar} - {carPrice:f2}");
        }
    }
}
