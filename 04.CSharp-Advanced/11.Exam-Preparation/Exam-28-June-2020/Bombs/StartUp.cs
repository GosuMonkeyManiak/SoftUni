using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //first Bomb effect
            //last bomb casing

            Queue<int> effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int daturaBomb = 0;
            int cherryBomb = 0;
            int smoke = 0;

            bool isPouchIsFull = false;

            while (effects.Count > 0 && casings.Count > 0)
            {
                int effect = effects.Peek();
                int casing = casings.Peek();

                if (daturaBomb >= 3 && cherryBomb >= 3 && smoke >= 3)
                {
                    isPouchIsFull = true;
                    break;
                }

                int sum = effect + casing;

                if (sum == 40)
                {
                    daturaBomb++;
                }
                else if (sum == 60)
                {
                    cherryBomb++;
                }
                else if (sum == 120)
                {
                    smoke++;
                }
                else
                {
                    casings.Pop();
                    casing -= 5;

                    casings.Push(casing);
                    continue;
                }

                effects.Dequeue();
                casings.Pop();
            }

            if (isPouchIsFull)
            {
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBomb}");
            Console.WriteLine($"Datura Bombs: {daturaBomb}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");
        }
    }
}
