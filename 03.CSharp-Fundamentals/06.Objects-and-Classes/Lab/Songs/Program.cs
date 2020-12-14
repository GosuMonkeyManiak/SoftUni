using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfSongs = int.Parse(Console.ReadLine());

            List<Song> allSongs = new List<Song>(numbersOfSongs);

            for (int i = 0; i < numbersOfSongs; i++)
            {
                List<string> currentSongs = Console.ReadLine()
                    .Split("_")
                    .ToList();

                Song currentSong = new Song();

                currentSong.TypeList = currentSongs[0];
                currentSong.Name = currentSongs[1];
                currentSong.Time = currentSongs[2];

                allSongs.Add(currentSong);
            }

            string temp = Console.ReadLine();

            if (temp == "all")
            {
                foreach (var item in allSongs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                for (int i = 0; i < allSongs.Count; i++)
                {
                    if (allSongs[i].TypeList == temp)
                    {
                        Console.WriteLine(allSongs[i].Name);
                    }
                }
            }
        }
    }
}
