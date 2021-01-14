using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> trafficJam = new Queue<string>();

            int totalCarsPassed = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                if (command == "green" && trafficJam.Count > 0)
                {
                    string currentCar = trafficJam.Peek();

                    for (int i = 0; i < greenDuration; i++)
                    {
                        currentCar = currentCar.Remove(0, 1);

                        if (currentCar.Length == 0)
                        {
                            trafficJam.Dequeue();
                            totalCarsPassed++;

                            if (trafficJam.Count > 0)
                            {
                                currentCar = trafficJam.Peek();
                            }
                            else
                            {
                                break;
                            }

                        }

                    }

                    for (int i = 0; i < freeWindow; i++)
                    {
                        if (i == 0 && currentCar.Length == 0)
                        {
                            break;
                        }

                        currentCar = currentCar.Remove(0, 1);

                        if (currentCar.Length == 0)
                        {
                            trafficJam.Dequeue();
                            totalCarsPassed++;
                            break;
                        }

                        if (i == freeWindow - 1 && currentCar.Length > 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{trafficJam.Peek()} was hit at {currentCar[0]}.");
                            return;
                        }

                    }

                }
                else
                {
                    trafficJam.Enqueue(command);
                }

            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
