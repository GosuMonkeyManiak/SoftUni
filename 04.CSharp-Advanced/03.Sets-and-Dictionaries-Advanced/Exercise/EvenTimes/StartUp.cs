using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<double, int> times = new Dictionary<double, int>();

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (!times.ContainsKey(number))
                {
                    times.Add(number, 0);
                }

                times[number]++;
            }

            var result = times.Where(x => x.Value % 2 == 0).FirstOrDefault();

            Console.WriteLine(result.Key);
        }
    }
}
