using System;

namespace ReportSystem
{
    class ReportSystem
    {
        static void Main(string[] args)
        {
            int expectMoney = int.Parse(Console.ReadLine());

            string producPrice = Console.ReadLine();
            int count = 1;

            int moneyFromCharity = 0;
            int countCashPeople = 0;
            int countCreditPeople = 0;
            double moneyFromCash = 0;
            double moneyFromCreditCards = 0;
            bool flag = false;

            while (producPrice != "End")
            {
                int price = int.Parse(producPrice);

                if (count % 2 == 0)
                {
                    if (price < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        countCreditPeople++;
                        moneyFromCreditCards += price;
                        moneyFromCharity += price;
                    }
                }
                else
                {
                    if (price > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        countCashPeople++;
                        moneyFromCash += price;
                        moneyFromCharity += price;
                    }
                }

                if (moneyFromCharity >= expectMoney)
                {
                    flag = true;
                    break;
                }

                producPrice = Console.ReadLine();
                count++;
            }

            if (flag)
            {
                Console.WriteLine($"Average CS: {moneyFromCash / countCashPeople:f2}");
                Console.WriteLine($"Average CC: {moneyFromCreditCards / countCreditPeople:f2}");
            }
            else
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
