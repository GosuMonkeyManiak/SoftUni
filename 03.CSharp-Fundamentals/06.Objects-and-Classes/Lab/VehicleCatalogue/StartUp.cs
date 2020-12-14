using System;
using System.Linq;
using System.Collections.Generic;

namespace VehicleCatalogue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Catalog newCatalog = new Catalog();

            while (true)
            {
                string inPut = Console.ReadLine();
                if (inPut == "end")
                {
                    break;
                }

                string[] intPutSplit = inPut
                    .Split('/', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (intPutSplit[0] == "Car")
                {
                    Car newCar = new Car();
                    newCar.Brand = intPutSplit[1];
                    newCar.Model = intPutSplit[2];
                    newCar.HoursePower = int.Parse(intPutSplit[3]);

                    newCatalog.Cars.Add(newCar);
                }
                else
                {
                    Truck newTruck = new Truck();
                    newTruck.Brand = intPutSplit[1];
                    newTruck.Model = intPutSplit[2];
                    newTruck.Weight = double.Parse(intPutSplit[3]);

                    newCatalog.Trucks.Add(newTruck);
                }
            }

            for (int i = 0; i < newCatalog.Cars.Count; i++)
            {
                for (int j = 0; j < newCatalog.Cars.Count - 1; j++)
                {
                    if (newCatalog.Cars[j].Brand.CompareTo(newCatalog.Cars[j + 1].Brand) == 1)
                    {
                        Car temp = newCatalog.Cars[j];
                        newCatalog.Cars[j] = newCatalog.Cars[j + 1];
                        newCatalog.Cars[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < newCatalog.Trucks.Count; i++)
            {
                for (int j = 0; j < newCatalog.Trucks.Count - 1; j++)
                {
                    if (newCatalog.Trucks[j].Brand.CompareTo(newCatalog.Trucks[j + 1].Brand) == 1)
                    {
                        Truck temp = newCatalog.Trucks[j];
                        newCatalog.Trucks[j] = newCatalog.Trucks[j + 1];
                        newCatalog.Trucks[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Cars:");
            foreach (var item in newCatalog.Cars)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.HoursePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (var item in newCatalog.Trucks)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
            }
        }
    }
}
