using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<VehicleCatalogue> vehicles = new List<VehicleCatalogue>();

            while (true)
            {
                string vehicle = Console.ReadLine();
                if (vehicle == "End")
                {
                    break;
                }

                string[] infoForVehicle = vehicle //typeOfVehicle model color horsePower
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                VehicleCatalogue newVehicle = new VehicleCatalogue();

                if (infoForVehicle[0] == "car")
                {
                    newVehicle = new VehicleCatalogue("Car", infoForVehicle[1], infoForVehicle[2], double.Parse(infoForVehicle[3]));
                }
                else
                {
                    newVehicle = new VehicleCatalogue("Truck", infoForVehicle[1], infoForVehicle[2], double.Parse(infoForVehicle[3]));
                }


                vehicles.Add(newVehicle);
            }

            while (true)
            {
                string models = Console.ReadLine();
                if (models == "Close the Catalogue")
                {

                    double sumCars = vehicles.Where(x => x.TypeOfVehicle == "Car").Sum(x => x.HorsePower);
                    double sumTrucks = vehicles.Where(x => x.TypeOfVehicle == "Truck").Sum(x => x.HorsePower);
                    List<VehicleCatalogue> cars = vehicles.Where(x => x.TypeOfVehicle == "Car").ToList();
                    List<VehicleCatalogue> trucks = vehicles.Where(x => x.TypeOfVehicle == "Truck").ToList();

                    if (cars.Count > 0)
                    {
                        Console.WriteLine($"Cars have average horsepower of: {sumCars / cars.Count:f2}.");
                    }
                    else
                    {
                        Console.WriteLine("Cars have average horsepower of: 0.00.");
                    }

                    if (trucks.Count > 0 )
                    {
                        Console.WriteLine($"Trucks have average horsepower of: {sumTrucks / trucks.Count:f2}.");
                    }
                    else
                    {
                        Console.WriteLine("Trucks have average horsepower of: 0.00.");
                    }
                    break;
                }

                foreach (var item in vehicles.Where(x => x.ModelOfVehicle == models))
                {
                    Console.WriteLine($"Type: {item.TypeOfVehicle}");
                    Console.WriteLine($"Model: {item.ModelOfVehicle}");
                    Console.WriteLine($"Color: {item.Color}");
                    Console.WriteLine($"Horsepower: {item.HorsePower}");
                }
            }
        }
    }
}
