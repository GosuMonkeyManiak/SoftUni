using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);

                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];

                int index = 0;
                for (int j = 5; j < tokens.Length; j += 2) //tires
                {
                    double pressure = double.Parse(tokens[j]);
                    int year = int.Parse(tokens[j + 1]);

                    Tire tire = new Tire(year, pressure);

                    tires[index] = tire;
                    index++;
                }

                Car currentCar = new Car(model, engine, cargo, tires);
                allCars.Add(currentCar);
            }

            string command = Console.ReadLine().ToLower();

            DecideWhoToPrint(command, allCars);

        }

        static void DecideWhoToPrint(string command, List<Car> allCars)
        {
            if (command == "fragile")
            {
                allCars = allCars
                    .Where(x => x.Cargo.CargoType == command && (x.ATirePressure() < 1 && x.ATirePressure() != 0))
                    .ToList();

                Print(allCars);
            }
            else if (command == "flamable")
            {
                allCars = allCars
                    .Where(x => x.Cargo.CargoType == command && x.Engine.EnginePower > 250)
                    .ToList();

                Print(allCars);
            }
        }

        static void Print(List<Car> allcars)
        {
            foreach (var car in allcars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
