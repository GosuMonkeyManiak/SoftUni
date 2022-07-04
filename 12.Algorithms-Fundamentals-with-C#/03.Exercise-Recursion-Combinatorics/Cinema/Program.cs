namespace Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static string[] names;
        private static string[] permutations;
        private static Dictionary<int, string> placeAndName;
        private static bool[] used;

        static void Main(string[] args)
        {
            names = Console.ReadLine()
                .Split(", ");

            permutations = new string[names.Length];
            placeAndName = new Dictionary<int, string>();
            used = new bool[names.Length];

            while (true)
            {
                string nameAndPlace = Console.ReadLine();

                if (nameAndPlace == "generate")
                {
                    break;
                }

                string[] nameAndPlaceParts = nameAndPlace.Split(" - ");

                string name = nameAndPlaceParts[0];
                int place = int.Parse(nameAndPlaceParts[1]);

                placeAndName.Add(place, name);
            }

            Permute(0);
        }

        static void Permute(int index)
        {
            if (index >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            if (placeAndName.ContainsKey(index + 1))
            {
                string name = placeAndName[index + 1];
                int nameIndex = names.ToList().FindIndex(x => x == name);

                used[nameIndex] = true;
                permutations[index] = name;
                Permute(index + 1);
            }
            else
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (!used[i] && !placeAndName.ContainsValue(names[i]))
                    {
                        used[i] = true;
                        permutations[index] = names[i];
                        Permute(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}