using System;

namespace FruitOrVegetable
{
    class FruitOrVegetable
    {
        static void Main(string[] args)
        {
            string fruitOrVege = Console.ReadLine();

            //banana, apple, kiwi, cherry, lemon и grapes
            //tomato, cucumber, pepper и carrot

            if (fruitOrVege == "banana" || fruitOrVege == "apple" || fruitOrVege == "kiwi" || fruitOrVege == "cherry" || fruitOrVege == "lemon" || fruitOrVege == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (fruitOrVege == "tomato" || fruitOrVege == "cucumber" || fruitOrVege == "pepper" || fruitOrVege == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
