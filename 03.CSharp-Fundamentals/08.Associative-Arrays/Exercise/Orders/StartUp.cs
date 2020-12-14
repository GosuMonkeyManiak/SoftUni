using System;
using System.Collections.Generic;

namespace Orders
{
    class Order
    {
        public double Price { get; set; }

        public int Quantity { get; set; }
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Order> orders = new Dictionary<string, Order>();

            while (true)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (info[0] == "buy")
                {
                    break;
                }

                string productName = info[0];
                double productPrice = double.Parse(info[1]);
                int productQuantity = int.Parse(info[2]);

                if (orders.ContainsKey(productName))
                {
                    orders[productName].Quantity += productQuantity;

                    if (orders[productName].Price != productPrice)
                    {
                        orders[productName].Price = productPrice;
                    }
                }
                else
                {
                    Order order = new Order();
                    order.Price = productPrice;
                    order.Quantity = productQuantity;

                    orders.Add(productName, order);
                }
            }

            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Price * item.Value.Quantity:f2}");
            }
        }
    }
}
