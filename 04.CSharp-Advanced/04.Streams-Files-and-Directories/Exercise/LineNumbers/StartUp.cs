using System;
using System.IO;

namespace LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                int countOfLetter = 0;
                int countOfPunctuationMark = 0;

                string word = lines[i];

                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (char.IsLetter(word[j]))
                    {
                        countOfLetter++;
                    }
                    else if (word[j] != ' ')
                    {
                        countOfPunctuationMark++;
                    }
                }


                word = $"Line {i + 1}: " + word + $"({countOfLetter})({countOfPunctuationMark})";
                lines[i] = word;
            }

            File.WriteAllLines("../../../output.txt", lines);

        }
    }
}
