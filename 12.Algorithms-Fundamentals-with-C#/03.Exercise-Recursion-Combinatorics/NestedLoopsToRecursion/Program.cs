namespace NestedLoopsToRecursion
{
    using System;

    class Program
    {
        private static int[] elements;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            elements = new int[n];

            RecursionLoops(n, 0, n);
        }

        static void RecursionLoops(int nLoops, int index, int n)
        {
            if (nLoops == 0)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                elements[index] = i;
                RecursionLoops(nLoops - 1, index + 1, n);
            }
        }
    }
}