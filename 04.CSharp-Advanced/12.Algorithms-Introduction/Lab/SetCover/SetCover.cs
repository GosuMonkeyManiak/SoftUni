using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    class SetCover
    {
        static void Main(string[] args)
        {
            int[] universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            int[][] sets = new[]
            {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

            List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (int[] set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            var result = new List<int[]>();

            while (universe.Count > 0)
            {
                var maxSet = sets.First();
                int maxCount = 0;

                foreach (var set in sets)
                {
                    int currentCount = set.Count(x => universe.Contains(x));

                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        maxSet = set;
                    }
                }

                result.Add(maxSet);

                sets.Remove(maxSet);

                foreach (var element in maxSet)
                {
                    universe.Remove(element);
                }
            }


            return result;
        }
    }
}
