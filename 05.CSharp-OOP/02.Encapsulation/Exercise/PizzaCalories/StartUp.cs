using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine()
                    .Split(" ");

                string[] doughInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Dough dough = new Dough(doughInfo[1], doughInfo[2], decimal.Parse(doughInfo[3]));

                Pizza pizza = new Pizza(pizzaName[1]) {Dough = dough};

                while (true)
                {
                    string[] topping = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (topping[0] == "END")
                    {
                        break;
                    }

                    pizza.AddTopping(new Topping(topping[1], decimal.Parse(topping[2])));
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
