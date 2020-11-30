using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string info = Console.ReadLine();
                if (info == "end")
                {
                    break;
                }

                string[] splitInfo = info
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Box currrentBox = new Box();
                currrentBox.SerialNumber = int.Parse(splitInfo[0]);
                currrentBox.Item.Name = splitInfo[1];
                currrentBox.ItemQuantity = int.Parse(splitInfo[2]);
                currrentBox.Item.Price = double.Parse(splitInfo[3]);
                currrentBox.PriceForBox = currrentBox.ItemQuantity * currrentBox.Item.Price;

                boxes.Add(currrentBox);
            }

            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = 0; j < boxes.Count - 1; j++)
                {
                    if (boxes[j].PriceForBox < boxes[j + 1].PriceForBox)
                    {
                        Box temp = boxes[j];
                        boxes[j] = boxes[j + 1];
                        boxes[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < boxes.Count; i++)
            {
                Console.WriteLine(boxes[i].SerialNumber);
                Console.WriteLine($"-- {boxes[i].Item.Name} - ${boxes[i].Item.Price:f2}: {boxes[i].ItemQuantity}");
                Console.WriteLine($"-- ${boxes[i].PriceForBox:f2}");
            }
        }
    }
}
