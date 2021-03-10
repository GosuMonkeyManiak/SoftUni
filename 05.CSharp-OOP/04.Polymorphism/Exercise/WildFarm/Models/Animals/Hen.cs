using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, Food food, double wingSize)
        : base(name, weight, food, wingSize)
        {
            
        }

        public override void ProducingSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Feed()
        {
            Weight += Food.FoodQuantity * 0.35;
            FoodEaten += Food.FoodQuantity;
        }
    }
}
