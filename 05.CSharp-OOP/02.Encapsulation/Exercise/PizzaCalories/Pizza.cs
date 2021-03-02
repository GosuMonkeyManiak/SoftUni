using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public IReadOnlyList<Topping> Toppings => toppings.AsReadOnly();

        public decimal TotalCalories => Total();

        public Dough Dough
        {
            set => dough = value;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        private decimal Total()
        {
            decimal total = dough.CalculateCalories();

            if (toppings.Count > 0)
            {
                foreach (var topping in toppings)
                {
                    total += topping.CalculateCalories();
                }
            }

            return total;
        }
    }
}
