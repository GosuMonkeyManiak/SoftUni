using System;

namespace Pets
{
    class Pets
    {
        static void Main(string[] args)
        {
            //inPut
            int days = int.Parse(Console.ReadLine());
            int kgFood = int.Parse(Console.ReadLine());

            double dogFoodkg = double.Parse(Console.ReadLine());//kg
            double catFoodkg = double.Parse(Console.ReadLine());//kg
            double turtleFoodkg = double.Parse(Console.ReadLine());//gr

            double allFood = (days * dogFoodkg) + (days * catFoodkg);
            double turtleFood = turtleFoodkg / 1000;
            turtleFood *= days;
            allFood += turtleFood;

            if (allFood <= kgFood)
            {
                Console.WriteLine($"{Math.Floor(kgFood - allFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(allFood - kgFood)} more kilos of food are needed.");
            }
        }
    }
}
