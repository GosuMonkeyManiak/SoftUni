using System;

namespace HoneyCombs
{
    class HoneyCombs
    {
        static void Main(string[] args)
        {
            int bees = int.Parse(Console.ReadLine());
            int flowers = int.Parse(Console.ReadLine());

            double allGramsHoney = bees * flowers * 0.21;

            int allCombs = (int)allGramsHoney / 100;
                        
            Console.WriteLine($"{allCombs} honeycombs filled.");

            double temp = allCombs * 100;
            allGramsHoney -= temp;

            Console.WriteLine($"{allGramsHoney:f2} grams of honey left.");
        }
    }
}
