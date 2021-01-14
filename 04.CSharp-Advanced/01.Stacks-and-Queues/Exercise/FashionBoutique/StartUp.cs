using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int capacityOfOneRack = int.Parse(Console.ReadLine());

            if (capacityOfOneRack == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Stack<int> boxOfClothes = new Stack<int>(clothes);

            int usedRacks = 0;
            int capacityOfRack = 0;

            while (boxOfClothes.Count > 0)
            {
                int clothe = boxOfClothes.Peek();

                if (clothe + capacityOfRack < capacityOfOneRack)
                {
                    capacityOfRack += clothe;
                }
                else if (clothe + capacityOfRack == capacityOfOneRack)
                {
                    usedRacks++;
                    capacityOfRack = 0;
                }
                else
                {
                    usedRacks++;
                    capacityOfRack = 0;

                    continue;
                }

                boxOfClothes.Pop();
            }

            if (capacityOfRack != 0)
            {
                usedRacks++;
                capacityOfRack = 0;
            }

            Console.WriteLine(usedRacks);

        }
    }
}
