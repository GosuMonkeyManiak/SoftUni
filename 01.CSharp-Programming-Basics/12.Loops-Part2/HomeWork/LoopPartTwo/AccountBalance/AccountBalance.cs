using System;
using System.Collections.Specialized;

namespace AccountBalance
{
    class AccountBalance
    {
        static void Main(string[] args)
        {
            int payment = int.Parse(Console.ReadLine());

            double sum = 0;
            int count = 0;

            while (count < payment)
            {
                double income = double.Parse(Console.ReadLine());
                if (income < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Increase: {income}");
                    sum += income;
                }

                count++;
            }

            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
