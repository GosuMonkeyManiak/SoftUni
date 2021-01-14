using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfCustomers = new Queue<int>(orders);

            Console.WriteLine(queueOfCustomers.Max());

            while (queueOfCustomers.Count > 0)
            {
                int quantityOfOrder = queueOfCustomers.Peek();

                if (quantityOfOrder > quantityOfFood)
                {
                    break;
                }

                quantityOfFood -= quantityOfOrder;
                queueOfCustomers.Dequeue();
            }

            if (queueOfCustomers.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queueOfCustomers)}");
            }
        }
    }
}
