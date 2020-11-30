using System;

namespace PetShop
{
    class PetShop
    {
        static void Main(string[] args)
        {
            int dogCount = int.Parse(Console.ReadLine());
            int otherPets = int.Parse(Console.ReadLine());

            double sum = (dogCount * 2.50) + (otherPets * 4);

            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
