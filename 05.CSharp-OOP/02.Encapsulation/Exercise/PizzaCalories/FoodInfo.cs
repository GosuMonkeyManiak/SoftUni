using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class FoodInfo
    {
        protected decimal weight; //grams

        protected FoodInfo()
        {
            
        }

        protected FoodInfo(decimal weight)
        {
            Weight = weight;
        }

        protected virtual decimal  Weight
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public virtual decimal CalculateCalories()
        {
            return 0;
        }
    }
}
