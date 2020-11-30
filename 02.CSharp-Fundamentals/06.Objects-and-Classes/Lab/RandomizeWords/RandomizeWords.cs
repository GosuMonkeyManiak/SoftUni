using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ")
                .ToList();

            Random rnd = new Random();

            for (int i = 0; i < words.Count; i++)
            {
                int newPosition = rnd.Next(words.Count);

                string temp = words[i];
                words[i] = words[newPosition];
                words[newPosition] = temp;
            }

            foreach (string item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
