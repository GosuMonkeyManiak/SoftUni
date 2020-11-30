using System;

namespace FuelTank
{
    class FuelTank
    {
        static void Main(string[] args)
        {
            string typeFuel = Console.ReadLine();
            double fuelLiter = double.Parse(Console.ReadLine());

            if (typeFuel == "Diesel")
            {
                if (fuelLiter >= 25)
                {
                    Console.WriteLine("You have enough diesel.");
                }
                else
                {
                    Console.WriteLine("Fill your tank with diesel!");
                }
            }
            else if (typeFuel == "Gasoline")
            {
                if (fuelLiter >= 25)
                {
                    Console.WriteLine("You have enough gasoline.");
                }
                else
                {
                    Console.WriteLine("Fill your tank with gasoline!");
                }
            }
            else if (typeFuel == "Gas")
            {
                if (fuelLiter >= 25)
                {
                    Console.WriteLine("You have enough gas.");
                }
                else
                {
                    Console.WriteLine("Fill your tank with gas!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}
