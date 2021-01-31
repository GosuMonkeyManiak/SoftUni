using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> allTires = new List<Tire[]>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "No")
                {
                    break;
                }

                Tire[] currentTires = new Tire[4];

                int tireIndex = 0;

                for (int i = 0; i <= tokens.Length; i+=2)
                {
                    if (i != 0)
                    {
                        int year = int.Parse(tokens[i - 2]);
                        double pressure = double.Parse(tokens[i - 1]);
                        Tire tire = new Tire(year, pressure);

                        currentTires[tireIndex] = tire;
                        tireIndex++;

                    }
                }

                allTires.Add(currentTires);
            }

            List<Engine> allEngines = new List<Engine>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Engines")
                {
                    break;
                }

                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                Engine currentEngine = new Engine(horsePower, cubicCapacity);

                allEngines.Add(currentEngine);
            }

            List<Car> allCars = new List<Car>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Show")
                {
                    break;
                }

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);

                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Car currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, allEngines[engineIndex], allTires[tiresIndex]);

                allCars.Add(currentCar);
            }

            allCars = DriveAllCars(allCars);
            Print(allCars);
        }

        static List<Car> DriveAllCars(List<Car> allCars)
        {
            allCars = allCars
                .Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 &&
                (x.SumOfPressure() > 9.0 && x.SumOfPressure() < 10.0))
                .ToList();

            foreach (var car in allCars)
            {
                car.Drive(20);
            }

            return allCars;
        }

        static void Print(List<Car> allCars)
        {
            foreach (var car in allCars)
            {
                car.WhoAmI();
            }
        }
    }
}
