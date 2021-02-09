using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int numbeOfBoxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbeOfBoxes; i++)
            {
                string text = Console.ReadLine();

                Box<string> newBox = new Box<string>(text);

                boxes.Add(newBox);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            boxes = Swap<Box<string>>(boxes, indexes[0], indexes[1]);

            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }

        static List<T> Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T element = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = element;

            return list;
        }
    }
}
