using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Vehicle> vehicles = InPut();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string type = parts[1];
                double litersOrKilometers = double.Parse(parts[2]);
                int index = vehicles.FindIndex(x => x.GetType().Name == type);

                switch (command)
                {
                    case "Drive":
                        vehicles[index].Drive(litersOrKilometers);
                        break;

                    case "Refuel":
                        vehicles[index].ReFuel(litersOrKilometers);
                        break;

                    case "DriveEmpty":
                        ((Bus) vehicles[index]).TurnOffAir();

                        vehicles[index].Drive(litersOrKilometers);

                        ((Bus)vehicles[index]).TurnOnAir();
                        break;
                }
            }

            int allIndex = vehicles.FindIndex(x => x.GetType().Name == "Car");
            Console.WriteLine(vehicles[allIndex]);

            allIndex = vehicles.FindIndex(x => x.GetType().Name == "Truck");
            Console.WriteLine(vehicles[allIndex]);

            allIndex = vehicles.FindIndex(x => x.GetType().Name == "Bus");
            Console.WriteLine(vehicles[allIndex]);
        }

        public static List<Vehicle> InPut()
        {
            string[] first = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] second = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] third = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Vehicle> vehicles = new List<Vehicle>();

            vehicles.Add(GetAVehicle(first));
            vehicles.Add(GetAVehicle(second));
            vehicles.Add(GetAVehicle(third));

            return vehicles;
        }

        public static Vehicle GetAVehicle(string[] info)
        {
            switch (info[0])
            {
                case "Car":
                    return new Car(double.Parse(info[1]), double.Parse(info[2])
                        , double.Parse(info[3]));

                case "Truck":
                    return new Truck(double.Parse(info[1]), double.Parse(info[2])
                        , double.Parse(info[3]));

                case "Bus":
                    return new Bus(double.Parse(info[1]), double.Parse(info[2])
                        , double.Parse(info[3]));
            }

            return null;
        }
    }
}
