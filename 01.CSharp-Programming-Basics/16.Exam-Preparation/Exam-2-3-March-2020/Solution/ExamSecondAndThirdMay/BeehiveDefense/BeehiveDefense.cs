using System;

namespace BeehiveDefense
{
    class BeehiveDefense
    {
        static void Main(string[] args)
        {
            int countBees = int.Parse(Console.ReadLine());// 1 healty 5 attack
            int health = int.Parse(Console.ReadLine());//beer
            int attack = int.Parse(Console.ReadLine());//beer

            bool isBeerWin = false;

            while (health > 0)
            {
                if (countBees < 100)
                {
                    isBeerWin = true;
                    break;
                }

                countBees -= attack;

                health -= countBees * 5;
            }

            if (isBeerWin)
            {
                if (countBees < 0)
                {
                    Console.WriteLine($"The bear stole the honey! Bees left {0}.");
                }
                else
                {
                    Console.WriteLine($"The bear stole the honey! Bees left {countBees}.");
                }
            }
            else
            {
                Console.WriteLine($"Beehive won! Bees left {countBees}.");
            }
        }
    }
}
