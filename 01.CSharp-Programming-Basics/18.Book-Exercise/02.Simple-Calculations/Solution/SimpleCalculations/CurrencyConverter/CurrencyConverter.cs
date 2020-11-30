using System;

namespace CurrencyConverter
{
    class CurrencyConverter
    {
        static void Main(string[] args)
        {
            double currenSum = double.Parse(Console.ReadLine());
            string from = Console.ReadLine();
            string until = Console.ReadLine();

            double newMoney = 0.0;

            if (from == "BGN")
            {
                if (until == "USD")
                {
                    newMoney = currenSum / 1.79549;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
                else if (until == "EUR")
                {
                    newMoney = currenSum / 1.95583;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
                else if (until == "GBP")
                {
                    newMoney = currenSum / 2.53405;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
            }
            else if (from == "USD")
            {
                if (until == "BGN")
                {
                    newMoney = currenSum * 1.79549;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
                else if (until == "EUR")
                {
                    newMoney = (currenSum * 1.79549) / 1.95583;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
                else if (until == "GBP")
                {
                    newMoney = (currenSum * 1.79549) / 2.53405;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
            }
            else if (from == "EUR")
            {
                if (until == "USD")
                {
                    newMoney = (currenSum * 1.95583) / 1.79549;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
                else if (until == "BGN")
                {
                    newMoney = currenSum * 1.95583;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
                else if (until == "GBP")
                {
                    newMoney = (currenSum * 1.95583) / 2.53405;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
            }
            else //GBP
            {
                if (until == "USD")
                {
                    newMoney = (currenSum * 2.53405) / 1.79549;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
                else if (until == "EUR")
                {
                    newMoney = (currenSum * 2.53405) / 1.95583;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
                else if (until == "BGN")
                {
                    newMoney = currenSum * 2.53405;
                    Console.WriteLine(Math.Round(newMoney, 2));
                }
            }
        }
    }
}
