namespace GeneratingCombinations
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void GenerateCombination(int[] set, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenerateCombination(set, vector, index + 1, i + 1);
                }
            }
        }

        public static void Main()
        {
            int[] set = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int k = int.Parse(Console.ReadLine());

            int[] vector = new int[k];

            int index = 0;

            int border = set.Length - k;

            GenerateCombination(set, vector, index, 0);
        }
    }
}