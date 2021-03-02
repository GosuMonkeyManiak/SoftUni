using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping : FoodInfo
    {
        private string toppingType;
        private decimal caloriesPerGram;

        public Topping(string toppingType, decimal weight)
        {
            ToppingType = toppingType;
            Weight = weight;
            caloriesPerGram = 2 * CaloriesPerSpecialTopping();
        }

        public decimal CaloriesPerGram => caloriesPerGram;

        protected override decimal Weight
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{toppingType} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        private string ToppingType
        {
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public override decimal CalculateCalories()
        {
            return (2 * weight) * CaloriesPerSpecialTopping();
        }

        private decimal CaloriesPerSpecialTopping()
        {
            string currentTopping = new string(toppingType.ToLower());

            if (currentTopping == "meat")
            {
                return 1.2m;
            }
            else if (currentTopping == "veggies")
            {
                return 0.8m;
            }
            else if (currentTopping == "cheese")
            {
                return 1.1m;
            }

            return 0.9m; //sauce
        }
    }
}
