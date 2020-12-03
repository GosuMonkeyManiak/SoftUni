using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @"[+][3][5][9]([ ]|[-])[2]\1[0-9]{3}\1[0-9]{4}\b";

            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
