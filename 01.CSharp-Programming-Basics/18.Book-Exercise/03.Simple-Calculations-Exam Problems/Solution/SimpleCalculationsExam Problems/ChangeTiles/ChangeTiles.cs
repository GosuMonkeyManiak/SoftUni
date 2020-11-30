using System;

namespace ChangeTiles
{
    class ChangeTiles
    {
        static void Main(string[] args)
        {
            int lenthPlayground = int.Parse(Console.ReadLine()); //square playground

            double widthPerTile = double.Parse(Console.ReadLine());
            double lengthPerTile = double.Parse(Console.ReadLine());

            int widthBench = int.Parse(Console.ReadLine());
            int lengthBench = int.Parse(Console.ReadLine());

            int playgroundVolume = lenthPlayground * lenthPlayground;

            double oneTileVolume = widthPerTile * lengthPerTile;

            int benchVolume = widthBench * lengthBench;

            playgroundVolume -= benchVolume;

            double tile = playgroundVolume / oneTileVolume;

            double time = tile * 0.2;

            Console.WriteLine(tile);
            Console.WriteLine(time);

        }
    }
}
