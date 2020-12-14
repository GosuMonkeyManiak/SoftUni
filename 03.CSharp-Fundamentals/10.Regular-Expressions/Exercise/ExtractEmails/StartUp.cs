using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+)(\b|(?=\s))";

            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}
