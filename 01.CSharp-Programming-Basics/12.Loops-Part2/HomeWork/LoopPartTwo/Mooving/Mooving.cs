using System;

namespace Mooving
{
    class Mooving
    {
        static void Main(string[] args)
        {
            int widthFreeSpace = int.Parse(Console.ReadLine());
            int lengthFreeSpace = int.Parse(Console.ReadLine());
            int heightFreeSpace = int.Parse(Console.ReadLine());

            double volumeFreeSpace = widthFreeSpace * lengthFreeSpace * heightFreeSpace;
            int cartons = 0;

            string cartonText = Console.ReadLine();

            while (cartonText != "Done")
            {
                int cart = int.Parse(cartonText);
                cartons += cart;

                if (cartons > volumeFreeSpace)
                {
                    break;
                }

                cartonText = Console.ReadLine();
            }

            if (cartons > volumeFreeSpace)
            {
                Console.WriteLine($"No more free space! You need {cartons - volumeFreeSpace} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{volumeFreeSpace - cartons} Cubic meters left.");
            }

        }
    }
}
