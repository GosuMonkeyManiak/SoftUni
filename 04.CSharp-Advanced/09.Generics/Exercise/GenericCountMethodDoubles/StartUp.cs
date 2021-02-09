using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                Box<double> num = new Box<double>(number);

                boxes.Add(num);
            }

            List<double> values = boxes
                .Select(x => x.Value)
                .ToList();

            double comparison = double.Parse(Console.ReadLine());

            int count = Compare<double>(values, comparison);

            Console.WriteLine(count);
        }

        static int Compare<T>(List<T> values, T comparison)
            where T : IComparable
        {
            int count = 0;

            foreach (var element in values)
            {
                if (element.CompareTo(comparison) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
