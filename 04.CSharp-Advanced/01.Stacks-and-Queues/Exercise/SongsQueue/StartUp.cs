using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
           string[] songs = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queueOfSongs = new Queue<string>(songs);


            while (queueOfSongs.Count > 0)
            {
                string inPut = Console.ReadLine();

                string[] tokens = inPut
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                

                switch (tokens[0].ToLower())
                {
                    case "play":
                        queueOfSongs.Dequeue();

                        break;

                    case "add":
                        int firstWhiteSpaceIndex = inPut.IndexOf(" ");
                        string song = inPut.Substring(firstWhiteSpaceIndex + 1);

                        if (queueOfSongs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            queueOfSongs.Enqueue(song);
                        }

                        break;

                    case "show":
                        Console.WriteLine(string.Join(", ", queueOfSongs));

                        break;
                }

            }

            Console.WriteLine("No more songs!");
        }
    }
}
