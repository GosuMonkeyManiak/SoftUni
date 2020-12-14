using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Furniture
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+(?:[\.]?\d*))!(?<quantity>\d+)";

            List<string> boughtItems = new List<string>();

            double moneySpent = 0.0;

            while (true)
            {
                string furniture = Console.ReadLine();
                if (furniture == "Purchase")
                {
                    break;
                }

                MatchCollection matches = Regex.Matches(furniture, pattern);

                foreach (Match match in matches)
                {
                    string item = match.Groups["furniture"].Value;
                    double itemPrice = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    moneySpent += quantity * itemPrice;

                    boughtItems.Add(item); 
                }
            }

            Console.WriteLine("Bought furniture:");


            foreach (string item in boughtItems)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {moneySpent:f2}");
        }
    }
}
