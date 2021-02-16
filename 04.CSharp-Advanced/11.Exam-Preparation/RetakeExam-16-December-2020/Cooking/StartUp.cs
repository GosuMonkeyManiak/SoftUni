using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int breads = 0;
            int cakes = 0;
            int pastry = 0;
            int fruitPie = 0;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int liquid = liquids.Peek();
                int ingredient = ingredients.Peek();

                int sum = liquid + ingredient;

                if (sum == 25) //bread
                {
                    breads++;
                }
                else if (sum == 50) //cake
                {
                    cakes++;
                }
                else if (sum == 75) //pastry
                {
                    pastry++;
                }
                else if (sum == 100) // fruit pie
                {
                    fruitPie++;
                }
                else //otherwise
                {
                    liquids.Dequeue();
                    ingredients.Pop();

                    ingredient += 3;
                    ingredients.Push(ingredient);
                    continue;
                }

                liquids.Dequeue();
                ingredients.Pop();
            }


            bool isCookedEveryThing = breads > 0 && cakes > 0 && pastry > 0 && fruitPie > 0;

            if (isCookedEveryThing)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Console.WriteLine($"Bread: {breads}");
            Console.WriteLine($"Cake: {cakes}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
        }
    }
}
