namespace PokemonDontGo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<int> distanceToPokemons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int sumOfAllRemovedElements = 0;

            while (distanceToPokemons.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0 && distanceToPokemons.Count >= 2)
                {
                    int elementToRemove = distanceToPokemons[0];
                    distanceToPokemons[0] = distanceToPokemons[^1];

                    IncreaseAndDecrease(distanceToPokemons, elementToRemove);

                    sumOfAllRemovedElements += elementToRemove;
                }
                else if (index > distanceToPokemons.Count - 1 && distanceToPokemons.Count >= 2)
                {
                    int elementToRemove = distanceToPokemons[^1];
                    distanceToPokemons[^1] = distanceToPokemons[0];

                    IncreaseAndDecrease(distanceToPokemons, elementToRemove);

                    sumOfAllRemovedElements += elementToRemove;
                }
                else
                {
                    int elementToRemove = distanceToPokemons[index];
                    distanceToPokemons.RemoveAt(index);

                    IncreaseAndDecrease(distanceToPokemons, elementToRemove);

                    sumOfAllRemovedElements += elementToRemove;
                }
            }

            Console.WriteLine(sumOfAllRemovedElements);
        }

        static void IncreaseAndDecrease(List<int> elements, int element)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] <= element)
                {
                    elements[i] += element;
                }
                else
                {
                    elements[i] -= element;
                }
            }
        }
    }
}
