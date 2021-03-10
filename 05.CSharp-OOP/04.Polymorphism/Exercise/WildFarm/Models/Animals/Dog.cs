using System;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, Food food, string livingRegion) 
            : base(name, weight, food, livingRegion)
        {

        }

        public override void ProducingSound()
        {
            Console.WriteLine("Woof!");
        }

        public override void Feed()
        {
            if (Food.GetType().Name == nameof(Meat))
            {
                Weight += Food.FoodQuantity * 0.40;
                FoodEaten += Food.FoodQuantity;
                return;
            }
            
            base.MessageForNotCorrectFood();
        }
    }
}