using System;

namespace FishTank
{
    class FishTank
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentBusySpace = double.Parse(Console.ReadLine());

            double volume = lenght * width * height;
            double allLiters = volume * 0.001;
            double percent = percentBusySpace * 0.01;

            double requimentLiter = allLiters * percent;

            Console.WriteLine($"{allLiters-requimentLiter:f3}");
        }
    }
}
