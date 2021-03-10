using System;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, Food food, string livingRegion, string breed) 
            : base(name, weight, food, livingRegion, breed)
        {
        }

        public override void ProducingSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Feed()
        {
            if (Food.GetType().Name == nameof(Vegetable) || Food.GetType().Name == nameof(Meat))
            {
                Weight += Food.FoodQuantity * 0.30;
                FoodEaten += Food.FoodQuantity;
                return;
            }

            base.MessageForNotCorrectFood();
        }
    }
}