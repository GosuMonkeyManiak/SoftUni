using System;

namespace FoodForPets
{
    class FoodForPets
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalFood = double.Parse(Console.ReadLine()); //gr

            int allEatenFoodFromDog = 0;
            int allEatenFoodFromCat = 0;
            double allEatenCokiest = 0.0;

            for (int i = 1; i <= days; i++)
            {
                int currentEatenFoodFromDog;
                int currentEatenFoodFromCat;
                double currentCokiest;
                
                if (i % 3 == 0)
                {
                    currentEatenFoodFromDog = int.Parse(Console.ReadLine());
                    currentEatenFoodFromCat = int.Parse(Console.ReadLine());

                    allEatenFoodFromDog += currentEatenFoodFromDog;
                    allEatenFoodFromCat += currentEatenFoodFromCat;

                    currentCokiest = (currentEatenFoodFromDog + currentEatenFoodFromCat) * 0.1;
                    allEatenCokiest += currentCokiest;
                }
                else
                {
                    currentEatenFoodFromDog = int.Parse(Console.ReadLine());
                    currentEatenFoodFromCat = int.Parse(Console.ReadLine());

                    allEatenFoodFromDog += currentEatenFoodFromDog;
                    allEatenFoodFromCat += currentEatenFoodFromCat;
                }
                
            }

            int allEatenFood = allEatenFoodFromCat + allEatenFoodFromDog;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(allEatenCokiest)}gr.");
            Console.WriteLine($"{1.0 * allEatenFood / totalFood * 100:f2}% of the food has been eaten.");
            Console.WriteLine($"{1.0 * allEatenFoodFromDog / allEatenFood * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{1.0 * allEatenFoodFromCat / allEatenFood * 100:f2}% eaten from the cat.");
        }
    }
}
