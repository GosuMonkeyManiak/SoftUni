using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Pieces> allPieces = new Dictionary<string, Pieces>();

            for (int i = 0; i < n; i++)
            {
                string[] pieces = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string piece = pieces[0];
                string composer = pieces[1];
                string key = pieces[2];

                if (allPieces.ContainsKey(piece) == false)
                {
                    allPieces.Add(piece, new Pieces()
                    {
                        Key = key,
                        Composer = composer
                    });
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Stop")
                {
                    break;
                }

                string command = tokens[0];
                string piece = string.Empty;
                string composer = string.Empty;
                string key = string.Empty; ;

                switch (command.ToUpper())
                {
                    case "ADD":
                        piece = tokens[1];
                        composer = tokens[2];
                        key = tokens[3];

                        if (allPieces.ContainsKey(piece))
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        else
                        {
                            allPieces.Add(piece, new Pieces()
                            {
                                Key = key,
                                Composer = composer
                            });
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }

                        break;

                    case "REMOVE":
                        piece = tokens[1];

                        if (allPieces.ContainsKey(piece))
                        {
                            allPieces.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;

                    case "CHANGEKEY":
                        piece = tokens[1];
                        key = tokens[2];

                        if (allPieces.ContainsKey(piece))
                        {
                            allPieces[piece].Key = key;
                            Console.WriteLine($"Changed the key of {piece} to {key}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;

                }

            }

            foreach (var item in allPieces.OrderBy(x => x.Key).ThenBy(x => x.Value.Composer))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.Composer}, Key: {item.Value.Key}");
            }


        }
    }
}
