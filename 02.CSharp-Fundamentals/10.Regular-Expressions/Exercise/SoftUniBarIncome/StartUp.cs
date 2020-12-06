using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SoftUniBarIncome
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @"\%(?<customer>[A-Z][a-z]+)\%[^\|\$\%\.]*?\<(?<product>\w+)\>[^\|\$\%\.]*?\|(?<quantity>\d+)\|[^\|\$\%\.]*?(?<price>[0-9]+(?:\.[0-9]+)?)\$";

            double totalIncome = 0.0;

            while (true)
            {
                string inPut = Console.ReadLine();
                if (inPut == "end of shift")
                {
                    break;
                }

                MatchCollection matches = Regex.Matches(inPut, pattern);

                string customerName = "";
                string productName = "";
                double totalPrice = 0.0;

                foreach (Match item in matches)
                {
                    customerName = item.Groups["customer"].Value;
                    productName = item.Groups["product"].Value;
                    totalPrice = int.Parse(item.Groups["quantity"].Value) * double.Parse(item.Groups["price"].Value);
                }

                totalIncome += totalPrice;

                if (customerName != "")
                {
                    Console.WriteLine($"{customerName}: {productName} - {totalPrice:f2}");
                }

            }
            
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }

    }

}
