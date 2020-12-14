using System;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @"([\|]|[\#])(?<item>[A-Za-z\s]+)\1(?<date>(?:[0-3][0-9]|[3][1-2])\/(?:[0][1-9]|[1][0-2])\/(?:[1-9][0-9]))\1(?<calories>\d+)\1";

            string text = Console.ReadLine();

            int allCalories = 0;

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match item in matches)
            {
                allCalories += int.Parse(item.Groups["calories"].Value);
            }

            int surviveDays = allCalories / 2000;

            Console.WriteLine($"You have food to last you for: {surviveDays} days!");

            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["item"]}, Best before: {item.Groups["date"]}, Nutrition: {item.Groups["calories"]}");
            }
        }
    }
}
