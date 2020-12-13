using System;
using System.Text.RegularExpressions;

namespace ProblemTwo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"(?<![\w\d\s\|])([\$]|[\%])(?<tag>[A-Z][a-z]{2,})\1[\:] (([\[])[0-9]+([\]])[\|]){3}(?![\w\d\[\]])";

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                Match match = Regex.Match(message, pattern);

                if (match.Length == 0)
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }
                else
                {
                    string digitPattern = @"\d+";
                    string decryptMessage = string.Empty;

                    MatchCollection matches = Regex.Matches(message, digitPattern);

                    foreach (Match item in matches)
                    {
                        int asciiCode = int.Parse(item.ToString());

                        decryptMessage += (char)(asciiCode);
                    }

                    Console.WriteLine($"{match.Groups["tag"]}: {decryptMessage}");
                }
            }
        }
    }
}
