using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValueInArray
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> times = new Dictionary<double, int>();

            foreach (double number in numbers)
            {
                if (!times.ContainsKey(number))
                {
                    times.Add(number, 0);
                }

                times[number]++;
            }

            foreach (var item in times)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
