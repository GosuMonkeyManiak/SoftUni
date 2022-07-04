namespace WordCruncher
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static string[] words;
        static string target;
        static Dictionary<int, List<string>> wordsOnIndex;
        static Dictionary<string, int> wordsCount;
        static List<string> combinations;
        static HashSet<string> uniqueCombinations;

        static void Main(string[] args)
        {
            wordsOnIndex = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            combinations = new List<string>();
            uniqueCombinations = new HashSet<string>();

            words = Console.ReadLine()
                .Split(", ");

            target = Console.ReadLine();

            foreach (var word in words)
            {
                int index = target.IndexOf(word);

                if (index == -1)
                {
                    continue;
                }

                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }

                wordsCount[word]++;

                if (!wordsOnIndex.ContainsKey(index))
                {
                    wordsOnIndex.Add(index, new List<string>());
                }

                wordsOnIndex[index].Add(word);

                while (true)
                {
                    index = target.IndexOf(word, index + 1);

                    if (index == -1)
                    {
                        break;
                    }

                    if (!wordsOnIndex.ContainsKey(index))
                    {
                        wordsOnIndex.Add(index, new List<string>());
                    }

                    wordsOnIndex[index].Add(word);
                }
            }

            GenSolutions(0);

            Console.WriteLine(string.Join("\n", uniqueCombinations));
        }

        static void GenSolutions(int index)
        {
            if (index >= target.Length)
            {
                uniqueCombinations.Add(string.Join(" ", combinations));
                return;
            }

            if (!wordsOnIndex.ContainsKey(index))
            {
                return;
            }

            foreach (var word in wordsOnIndex[index])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                combinations.Add(word);
                wordsCount[word]--;

                GenSolutions(index + word.Length);

                combinations.RemoveAt(combinations.Count - 1);
                wordsCount[word]++;
            }
        }
    }
}