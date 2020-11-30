using System;

namespace SumSeconds
{
    class SumSeconds
    {
        static void Main(string[] args)
        {
            int sec1 = int.Parse(Console.ReadLine());
            int sec2 = int.Parse(Console.ReadLine());
            int sec3 = int.Parse(Console.ReadLine());

            int allSeconds = sec1 + sec2 + sec3;

            int minuts = allSeconds / 60;
            int seconds = allSeconds % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minuts}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minuts}:{seconds}");
            }
        }
    }
}
