using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (!occurrences.ContainsKey(currentChar))
                {
                    occurrences.Add(currentChar, 0);
                }

                occurrences[currentChar]++;
            }

            foreach (var character in occurrences)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
