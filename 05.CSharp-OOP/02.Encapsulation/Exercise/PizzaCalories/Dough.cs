using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough : FoodInfo
    {
        private string flourType;
        private string backing;
        private decimal caloriesPerGram;

        public Dough(string flourType, string backing, decimal weight)
            : base(weight)
        {
            FlourType = flourType;
            Backing = backing;
            caloriesPerGram = 2 * CaloriesForSpecialDough() * CaloriesForSpecialBacking();
        }

        public decimal CaloriesPerGram => caloriesPerGram;

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        private string Backing
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }

                backing = value;
            }
        }

        public override decimal CalculateCalories()
        {
            return (2 * weight) * CaloriesForSpecialDough() * CaloriesForSpecialBacking();
        }

        private decimal CaloriesForSpecialDough()
        {
            string currentFlour = new string(flourType.ToLower());

            if (currentFlour == "white")
            {
                return 1.5m;
            }

            return 1.0m; //wholegrain
        }

        private decimal CaloriesForSpecialBacking()
        {
            string currentBacking = new string(backing.ToLower());

            if (currentBacking == "crispy")
            {
                return 0.9m;
            }
            else if (currentBacking == "chewy")
            {
                return 1.1m;
            }

            return 1.0m; //homemade
        }
    }
}
