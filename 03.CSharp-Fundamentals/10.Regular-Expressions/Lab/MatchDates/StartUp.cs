using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();

            string pattern = @"\b(?<day>(?:[0-2][0-9])|(?:3[0-2]))(?<separator>[\.\-\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})\b";

            MatchCollection matches = Regex.Matches(date,pattern);

            foreach (Match item in matches)
            {
                Console.WriteLine($"Day: {item.Groups["day"].Value}, Month: {item.Groups["month"].Value}, Year: {item.Groups["year"].Value}");
            }
            
        }
    }
}
