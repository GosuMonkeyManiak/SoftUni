using System;
using System.Collections.Generic;
using System.Linq;

namespace CountUppercaseWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> sentence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> upperCase = GetOnlyUpperCase(sentence, x => char.IsUpper(x[0]));

            for (int i = 0; i < upperCase.Count; i++)
            {
                Console.WriteLine(upperCase[i]);
            }
        }


        static List<string> GetOnlyUpperCase(List<string> words, Func<string,bool> condition)
        {
            List<string> upperCase = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                if (condition(words[i]))
                {
                    upperCase.Add(words[i]);
                }
            }

            return upperCase;
        }
    }
}
