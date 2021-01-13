using System;
using System.Collections.Generic;

namespace Trafficjam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCarsCanPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int passCars = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                if (command == "green")
                {
                    if (numberOfCarsCanPass > cars.Count)
                    {
                        for (int i = 0; i < cars.Count; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passCars++;
                            i--;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < numberOfCarsCanPass; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passCars++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

            }

            Console.WriteLine($"{passCars} cars passed the crossroads.");
        }
    }
}
