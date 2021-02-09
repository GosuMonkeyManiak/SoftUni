using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                Box<int> newBox = new Box<int>(number);

                boxes.Add(newBox);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            boxes = Swap<Box<int>>(boxes, indexes[0], indexes[1]);

            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }

        static List<T> Swap<T>(List<T> boxes, int firstIndex, int secondIndex)
        {
            T element = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = element;

            return boxes;
        }
    }
}
