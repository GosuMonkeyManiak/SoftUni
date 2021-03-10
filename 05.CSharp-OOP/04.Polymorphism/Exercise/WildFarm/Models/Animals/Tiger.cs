using System;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, Food food, string livingRegion, string breed) : 
            base(name, weight, food, livingRegion, breed)
        {
        }

        public override void ProducingSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Feed()
        {
            if (Food.GetType().Name == nameof(Meat))
            {
                Weight += Food.FoodQuantity * 1;
                FoodEaten += Food.FoodQuantity;
                return;
            }

            base.MessageForNotCorrectFood();
        }
    }
}