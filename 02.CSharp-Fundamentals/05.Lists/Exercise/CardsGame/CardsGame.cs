using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class CardsGame
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondDeck = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            while (secondDeck.Count > 0 && firstDeck.Count > 0)
            {
                if (firstDeck[0] > secondDeck[0])
                {
                    firstDeck.Add(firstDeck[0]);
                    firstDeck.Add(secondDeck[0]);

                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
                else if (secondDeck[0] > firstDeck[0])
                {
                    secondDeck.Add(secondDeck[0]);
                    secondDeck.Add(firstDeck[0]);

                    secondDeck.RemoveAt(0);
                    firstDeck.RemoveAt(0);
                }
                else
                {
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
            }

            if (firstDeck.Count > 0)
            {
                int sum = 0;

                foreach (int item in firstDeck)
                {
                    sum += item;    
                }

                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                int sum = 0;

                foreach (int item in secondDeck)
                {
                    sum += item;
                }

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
