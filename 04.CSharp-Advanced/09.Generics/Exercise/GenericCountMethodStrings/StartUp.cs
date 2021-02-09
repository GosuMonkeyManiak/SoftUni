using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                Box<string> box = new Box<string>(text);

                boxes.Add(box);
            }

            List<string> values = boxes
                .Select(x => x.Element)
                .ToList();

            string comparison = Console.ReadLine();

            int count = Compare<string>(values, comparison);

            Console.WriteLine(count);
        }

        static int Compare<T>(List<T> boxes, T comparison)
            where T : IComparable<T>
        {
            int count = 0;

            foreach (var value in boxes)
            {
                if (value.CompareTo(comparison) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
