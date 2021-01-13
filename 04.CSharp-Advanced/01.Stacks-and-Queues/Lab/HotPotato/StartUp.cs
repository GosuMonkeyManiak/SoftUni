using System;
using System.Collections.Generic;

namespace HotPotato
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] players = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int tossForLeave = int.Parse(Console.ReadLine());

            Queue<string> hotPotato = new Queue<string>(players);

            int toss = 0;

            while (hotPotato.Count > 1)
            {
                toss++;

                if (toss == tossForLeave)
                {
                    Console.WriteLine($"Removed {hotPotato.Dequeue()}");
                    toss = 0;
                }
                else
                {
                    hotPotato.Enqueue(hotPotato.Dequeue());
                }
            }

            Console.WriteLine($"Last is {hotPotato.Dequeue()}");
        }
    }
}
