using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();

            string pattern = @"([\=]|[\/])(?<word>[A-Z][A-Za-z]{2,})\1";
            MatchCollection matches = Regex.Matches(places, pattern);

            List<string> result = new List<string>();

            int travelPoints = 0;

            foreach (Match place in matches)
            {
                travelPoints += place.Groups["word"].Value.Length;

                result.Add(place.Groups["word"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", result)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
