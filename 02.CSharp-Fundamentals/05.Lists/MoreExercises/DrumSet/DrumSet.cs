using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class DrumSet
    {
        static void Main(string[] args)
        {
            double saveMoney = double.Parse(Console.ReadLine());

            List<int> drumSet = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> quality = new List<int>();

            foreach (int item in drumSet)
            {
                quality.Add(item);
            }

            while (true)
            {
                string power = Console.ReadLine();
                if (power == "Hit it again, Gabsy!")
                {
                    Console.WriteLine(string.Join(" ", drumSet));
                    Console.WriteLine($"Gabsy has {saveMoney:f2}lv.");
                    break;
                }

                int hitpower = int.Parse(power);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitpower;

                    if (drumSet[i] <= 0) //!!
                    {
                        double price = quality[i] * 3;

                        if (price <= saveMoney)
                        {
                            saveMoney -= price;
                            drumSet[i] = quality[i];
                        }
                        else
                        {
                            quality.RemoveAt(i);
                            drumSet.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }
    }
}
