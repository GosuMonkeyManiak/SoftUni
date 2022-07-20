namespace Set_Cover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            List<int>[] sets = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                var subSet = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                sets[i] = subSet;
            }

            List<int[]> selectedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                var currentSet = sets
                    .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                    .FirstOrDefault()
                    .ToArray();

                selectedSets.Add(currentSet);

                for (int i = 0; i < currentSet.Length; i++)
                {
                    universe.Remove(currentSet[i]);
                }
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            for (int i = 0; i < selectedSets.Count; i++)
            {
                Console.WriteLine(string.Join(", ", selectedSets[i]));
            }
        }
    }
}