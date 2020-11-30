using System;

namespace FuelTankPTTwo
{
    class FuelTankPTTwo
    {
        static void Main(string[] args)
        {
            string typeFuel = Console.ReadLine();
            double fuelLiter = double.Parse(Console.ReadLine());
            string clubCart = Console.ReadLine();

            double price = 0.0;

            if (clubCart == "Yes")
            {
                if (typeFuel == "Gas")
                {
                    //0.93 - 8 cents
                    price = fuelLiter * 0.85;

                }
                else if (typeFuel == "Gasoline")
                {
                    //2.22 - 18 cents
                    price = fuelLiter * 2.04;
                }
                else if (typeFuel == "Diesel")
                {
                    //2.33 - 12 cents
                    price = fuelLiter * 2.21;
                }
            }
            else
            {
                if (typeFuel == "Gas")
                {
                    price = fuelLiter * 0.93;
                }
                else if (typeFuel == "Gasoline")
                {
                    price = fuelLiter * 2.22;
                }
                else if (typeFuel == "Diesel")
                {
                    price = fuelLiter * 2.33;
                }
            }

            if (fuelLiter >= 20 && fuelLiter <= 25)
            {
                double discount = price * 0.08;
                price -= discount;
            }
            else if (fuelLiter > 25)
            {
                double discount = price * 0.10;
                price -= discount;
            }

            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
