using System;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, Food food, double wingSize) 
            : base(name, weight, food, wingSize)
        {

        }

        public override void ProducingSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Feed()
        {
            if (Food.GetType().Name == nameof(Meat))
            {
                Weight += Food.FoodQuantity * 0.25;
                FoodEaten += Food.FoodQuantity;
                return;
            }

            base.MessageForNotCorrectFood();
        }
    }
}
