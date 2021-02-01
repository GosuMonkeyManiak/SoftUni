using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> allCars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumption = double.Parse(tokens[2]);

                if (!allCars.ContainsKey(model))
                {
                    Car currentCar = new Car(model, fuelAmount, fuelConsumption);
                    allCars.Add(model, currentCar);
                }

            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "End")
                {
                    break;
                }

                string model = tokens[1];
                double kilometers = double.Parse(tokens[2]);

                if (allCars.ContainsKey(model))
                {
                    allCars[model].Drive(kilometers);
                }

            }

            Print(allCars);

        }

        static void Print(Dictionary<string, Car> allCars)
        {
            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
            }
        }
    }
}
