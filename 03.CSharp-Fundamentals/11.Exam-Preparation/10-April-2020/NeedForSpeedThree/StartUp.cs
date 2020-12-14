using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedThree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            Dictionary<string, CarInfo> allCars = new Dictionary<string, CarInfo>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string carName = tokens[0];
                int mileAge = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);

                if (allCars.ContainsKey(carName) == false)
                {
                    allCars.Add(carName, new CarInfo()
                    {
                        MileAge = mileAge,
                        Fuel = fuel
                    });
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Stop")
                {
                    break;  
                }

                string command = tokens[0];
                string carName = tokens[1];

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(tokens[2]); //543
                        int fuel = int.Parse(tokens[3]); //47

                        if (allCars[carName].MileAge >= 100000)
                        {   
                            allCars.Remove(carName);
                            Console.WriteLine($"Time to sell the {carName}!");

                            continue;
                        }

                        if (allCars[carName].Fuel >= fuel)
                        {
                            allCars[carName].Fuel -= fuel;
                            allCars[carName].MileAge += distance;
                            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }

                        if (allCars[carName].MileAge >= 100000)
                        {
                            allCars.Remove(carName);
                            Console.WriteLine($"Time to sell the {carName}!");
                        }

                        break;

                    case "Refuel":
                        int reFuel = int.Parse(tokens[2]);

                        if (allCars[carName].Fuel == 75)
                        {
                            Console.WriteLine($"{carName} refueled with 0 liters");
                        }
                        else
                        {
                            int neededFuelToFull = 75 - allCars[carName].Fuel;

                            if (neededFuelToFull >= reFuel)
                            {
                                allCars[carName].Fuel += reFuel;
                                Console.WriteLine($"{carName} refueled with {reFuel} liters");
                            }
                            else
                            {
                                allCars[carName].Fuel += neededFuelToFull;
                                Console.WriteLine($"{carName} refueled with {neededFuelToFull} liters");
                            }
                        }
                        break;

                    case "Revert":
                        int kilometers = int.Parse(tokens[2]);

                        allCars[carName].MileAge -= kilometers;

                        if (allCars[carName].MileAge < 10000)
                        {
                            allCars[carName].MileAge = 10000;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                        }
                        break;

                }

            }

            allCars = allCars.OrderByDescending(x => x.Value.MileAge)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.MileAge} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}
