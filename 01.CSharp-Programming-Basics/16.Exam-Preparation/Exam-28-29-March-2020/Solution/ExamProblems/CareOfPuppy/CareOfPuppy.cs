using System;

namespace CareOfPuppy
{
    class CareOfPuppy
    {
        static void Main(string[] args)
        {
            int foodForDogKg = int.Parse(Console.ReadLine());
            int allFoodInGrams = foodForDogKg * 1000;
            int allEatenFoodInGrams = 0;

            while (true)
            {
                string foodPerEatingGrams = Console.ReadLine();
                if (foodPerEatingGrams == "Adopted")
                {
                    break;
                }

                int currentFoodInGrams = int.Parse(foodPerEatingGrams);

                allEatenFoodInGrams += currentFoodInGrams;
            }

            if (allFoodInGrams >= allEatenFoodInGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {allFoodInGrams - allEatenFoodInGrams} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {allEatenFoodInGrams - allFoodInGrams} grams more.");
            }
        }
    }
}
