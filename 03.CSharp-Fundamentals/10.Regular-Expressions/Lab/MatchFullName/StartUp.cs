using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine(string.Join(' ', matches));
        }
    }
}
