using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([\@]|[\#])(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";

            List<string> words = new List<string>();

            MatchCollection matches = Regex.Matches(text, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            foreach (Match word in matches)
            {
                string firstWord = word.Groups["firstWord"].Value;
                string secondWord = word.Groups["secondWord"].Value;

                char[] characters = secondWord.ToCharArray();
                Array.Reverse(characters);
                string newString = new string(characters);

                if (firstWord == newString)
                {
                    words.Add(firstWord + " <=> " + secondWord);
                }
            }

            if (words.Count == 0)
            {
                Console.WriteLine("No mirror words!");
                return;
            }

            Console.WriteLine("The mirror words are:");
            Console.WriteLine(string.Join(", ", words));
        }
    }
}
