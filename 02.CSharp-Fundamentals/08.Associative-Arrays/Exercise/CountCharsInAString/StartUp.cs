using System;
using System.Collections.Generic;

namespace CountCharsInAString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> numbersCharacters = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals(' '))
                {
                    continue;
                }

                if (numbersCharacters.ContainsKey(text[i]))
                {
                    numbersCharacters[text[i]]++;
                }
                else
                {
                    numbersCharacters.Add(text[i], 1);
                }
            }

            foreach (var item in numbersCharacters)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
