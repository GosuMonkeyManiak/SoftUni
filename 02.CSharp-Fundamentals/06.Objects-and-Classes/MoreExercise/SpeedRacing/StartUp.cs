using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>(n);

            for (int i = 0; i < n; i++)
            {
                string[] infoAboutCar = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car newCar = new Car(infoAboutCar[0], double.Parse(infoAboutCar[1]), double.Parse(infoAboutCar[2]));
                allCars.Add(newCar);
            }

            while (true)
            {
                string driveCar = Console.ReadLine();
                if (driveCar == "End")
                {

                    foreach (var item in allCars)
                    {
                        Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TraveledDistance}");
                    }
                    break;
                }

                string[] info = driveCar
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car temp = allCars.Where(x => x.Model == info[1]).FirstOrDefault();

                bool isMove = temp.MovingCar(double.Parse(info[2]));

                if (!isMove)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }
    }
}
