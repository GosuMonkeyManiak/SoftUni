using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicCards
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> myDeck = new List<string>();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (commands[0] == "Ready")
                {
                    Console.WriteLine(string.Join(" ", myDeck));
                    break;
                }

                switch (commands[0])
                {
                    case "Add":

                        string addCardName = commands[1];

                        if (!cards.Contains(addCardName))
                        {
                            Console.WriteLine("Card not found.");
                            break;
                        }

                        myDeck.Add(addCardName);

                        break;

                    case "Insert":

                        string insertCardName = commands[1];
                        int insertIndexCard = int.Parse(commands[2]);

                        if (!cards.Contains(insertCardName))
                        {
                            Console.WriteLine("Error!");
                            break;
                        }

                        if (insertIndexCard < 0 || insertIndexCard > myDeck.Count - 1)
                        {
                            Console.WriteLine("Error!");
                            break;
                        }

                        myDeck.Insert(insertIndexCard, insertCardName);

                        break;

                    case "Remove":

                        string cardForRemove = commands[1];

                        if (!myDeck.Contains(cardForRemove))
                        {
                            Console.WriteLine("Card not found.");
                            break;
                        }

                        myDeck.Remove(cardForRemove);

                        break;

                    case "Swap":

                        string firstCardName = commands[1];
                        string secondCardName = commands[2];

                        int firstCardIndex = myDeck.FindIndex(x => x == firstCardName);
                        int secondCardIndex = myDeck.FindIndex(x => x == secondCardName);

                        string temp = myDeck[firstCardIndex];
                        myDeck[firstCardIndex] = myDeck[secondCardIndex];
                        myDeck[secondCardIndex] = temp;

                        break;

                    case "Shuffle":

                        myDeck.Reverse();

                        break;
                }
            }
        }
    }
}
