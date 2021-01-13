using System;
using System.Collections.Generic;

namespace SuperMarket
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                if (name == "Paid")
                {
                    Console.WriteLine(string.Join("\n",customers));
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(name);
                }

            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
