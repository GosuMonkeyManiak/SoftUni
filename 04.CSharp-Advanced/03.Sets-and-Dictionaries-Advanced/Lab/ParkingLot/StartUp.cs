using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<string> carsLicens = new HashSet<string>();

            while (true)
            {
                string[] inOrOut = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (inOrOut[0] == "END")
                {
                    break;
                }

                if (inOrOut[0] == "OUT" && carsLicens.Contains(inOrOut[1]))
                {
                    carsLicens.Remove(inOrOut[1]);
                }
                else if (inOrOut[0] == "IN")
                {
                    carsLicens.Add(inOrOut[1]);
                }
            }

            if (carsLicens.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in carsLicens)
            {
                Console.WriteLine(car);
            }

        }
    }
}
