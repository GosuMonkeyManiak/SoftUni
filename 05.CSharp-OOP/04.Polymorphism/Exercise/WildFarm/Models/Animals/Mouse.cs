using System;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, Food food, string livingRegion) 
            : base(name, weight, food, livingRegion)
        {

        }

        public override void ProducingSound()
        {
            Console.WriteLine("Squeak");
        }

        public override void Feed()
        {
            if (Food.GetType().Name == nameof(Vegetable) || Food.GetType().Name == nameof(Fruit))
            {
                Weight += Food.FoodQuantity * 0.10;
                FoodEaten += Food.FoodQuantity;
                return;
            }
            
            base.MessageForNotCorrectFood();
        }
    }
}