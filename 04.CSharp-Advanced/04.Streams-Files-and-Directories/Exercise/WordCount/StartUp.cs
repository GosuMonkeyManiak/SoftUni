using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> times = new Dictionary<string, int>();

            string[] words = File.ReadAllLines("../../../words.txt");
            string[] text = File.ReadAllLines("../../../text.txt");

            for (int i = 0; i < text.Length; i++)
            {
                text[i] = text[i].Remove(0, 1);
            }

            for (int i = 0; i < words.Length; i++)
            {
                int time = 0;
                string word = words[i];

                for (int j = 0; j < text.Length; j++) //sentence
                {
                    text[j] = text[j].Replace(',', ' ');
                    text[j] = text[j].Replace('.', ' ');
                    text[j] = text[j].ToLower();
                    string[] splitted = text[j].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (int k = 0; k < splitted.Length; k++) //word of sentence
                    {
                        if (splitted[k] == word)
                        {
                            time++;
                        }
                    }

                }

                times.Add(word, time);

            }

            string[] actulaResult = new string[times.Count];
            int index = 0;

            foreach (var word in times)
            {
                actulaResult[index] = $"{word.Key} - {word.Value}";
                index++;
            }

            File.WriteAllLines("../../../actualResult.txt", actulaResult);

            times = times.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            string[] expectedResult = new string[times.Count];
            index = 0;

            foreach (var word in times)
            {
                expectedResult[index] = $"{word.Key} - {word.Value}";
                index++;
            }

            File.WriteAllLines("../../../expectedResult.txt", expectedResult);
        }
    }
}
