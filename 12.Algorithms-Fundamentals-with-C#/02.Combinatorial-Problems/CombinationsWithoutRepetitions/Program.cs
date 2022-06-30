namespace CombinationsWithoutRepetitions
{
    using System;

    class Program
    {
        private static string[] elements;
        private static string[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            int slots = int.Parse(Console.ReadLine());
            combinations = new string[slots];

            Combinations(0, 0);
        }

        static void Combinations(int index, int start)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Combinations(index + 1, i);
            }
        }
    }
}