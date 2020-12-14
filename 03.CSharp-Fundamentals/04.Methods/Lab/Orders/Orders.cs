using System;

namespace Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculationTotalPrice(product, quantity);
        }

        public static void CalculationTotalPrice(string product, int quantity)
        {
            switch (product)
            {
                case "coffee":
                    Console.WriteLine($"{(decimal)(quantity * 1.50):f2}");
                    break;

                case "water":
                    Console.WriteLine($"{(decimal)(quantity * 1.00):f2}");
                    break;

                case "coke":
                    Console.WriteLine($"{(decimal)(quantity * 1.40):f2}");
                    break;

                case "snacks":
                    Console.WriteLine($"{(decimal)(quantity * 2.00):f2}");
                    break;
            }
        }
    }
}
