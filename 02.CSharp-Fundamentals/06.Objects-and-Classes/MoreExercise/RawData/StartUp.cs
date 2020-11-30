using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car newCar = new Car(info[0], int.Parse(info[1]), int.Parse(info[2]), int.Parse(info[3]), info[4]);

                allCars.Add(newCar);
            }

            string command = Console.ReadLine();

            List<Car> result = new List<Car>();

            if (command == "fragile")
            {
                result = allCars.Where(x => x.Cargo.CargoType == command).Where(x => x.Cargo.CargoWeight < 1000).ToList();
            }
            else
            {
                result = allCars.Where(x => x.Cargo.CargoType == command).Where(x => x.Engine.EnginePower > 250).ToList();
            }

            foreach (var item in result)
            {
                Console.WriteLine(item.Model);
            }
        }
    }
}
