using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //n engines

            Dictionary<string, Engine> allEngines = new Dictionary<string, Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int power = int.Parse(tokens[1]);

                Engine currentEngine = new Engine(model, power);

                if (tokens.Length == 4)
                {
                    int displacement = int.Parse(tokens[2]);
                    string efficiency = tokens[3];

                    currentEngine.Displacement = displacement;
                    currentEngine.Efficiency = efficiency;
                }
                else if (tokens.Length == 3)
                {
                    bool checkForEfficiencyOrDisPlacement = int.TryParse(tokens[2], out int displacement);

                    if (checkForEfficiencyOrDisPlacement)
                    {
                        displacement = int.Parse(tokens[2]);
                        currentEngine.Displacement = displacement;
                    }
                    else
                    {
                        currentEngine.Efficiency = tokens[2];
                    }
                }

                if (!allEngines.ContainsKey(model))
                {
                    allEngines.Add(model, currentEngine);
                }

            }

            int m = int.Parse(Console.ReadLine()); //cars

            List<Car> allCars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                string engine = tokens[1];

                Car currentCar = new Car(model, allEngines[engine]);

                if (tokens.Length == 4)
                {
                    int weight = int.Parse(tokens[2]);
                    string color = tokens[3];

                    currentCar.Weight = weight;
                    currentCar.Color = color;
                }
                else if (tokens.Length == 3)
                {
                    bool checkForWeightOrColor = int.TryParse(tokens[2], out int weight);

                    if (checkForWeightOrColor)
                    {
                        currentCar.Weight = weight;
                    }
                    else
                    {
                        currentCar.Color = tokens[2];
                    }

                }

                allCars.Add(currentCar);
            }

            Print(allCars);

        }

        static void Print(List<Car> allCars)
        {
            foreach (var car in allCars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
