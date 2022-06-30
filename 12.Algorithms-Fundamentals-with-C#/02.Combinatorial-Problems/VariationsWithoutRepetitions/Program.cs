namespace VariationsWithoutRepetitions
{
    using System;

    class Program
    {
        private static string[] elements;
        private static string[] variantions;
        private static bool[] used;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            int slots = int.Parse(Console.ReadLine());
            variantions = new string[slots];

            used = new bool[elements.Length];

            Variantions(0);
        }

        static void Variantions(int index)
        {
            if (index >= variantions.Length)
            {
                Console.WriteLine(string.Join(" ", variantions));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variantions[index] = elements[i];
                    Variantions(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}