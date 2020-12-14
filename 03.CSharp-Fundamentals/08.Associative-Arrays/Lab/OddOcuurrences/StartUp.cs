using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOcuurrences
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> ocuurs = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (ocuurs.ContainsKey(word.ToLower()))
                {
                    ocuurs[word.ToLower()]++;
                }
                else
                {
                    ocuurs.Add(word.ToLower(), 1);
                }
            }

            foreach (var item in ocuurs)
            {
                if (item.Value % 2 == 0)
                {
                    ocuurs.Remove(item.Key);
                }
            }

            foreach (var item in ocuurs)
            {
                Console.Write($"{item.Key.ToLower()} ");
            }

        }
    }
}
