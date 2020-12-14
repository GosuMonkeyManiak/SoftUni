using System;

namespace PokeMon
{
    class PokeMon
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine()); // N
            int distanceBetweenTarget = int.Parse(Console.ReadLine()); // M
            byte exhaustionFactor = byte.Parse(Console.ReadLine()); // Y

            decimal fiftyPercantage = pokePower * 0.5M;
            int half = (int)fiftyPercantage;

            int pokeTargets = 0;
            //n - m 

            while (pokePower >= distanceBetweenTarget)
            {
                int subcrating = pokePower - distanceBetweenTarget;
                pokePower -= distanceBetweenTarget;
                pokeTargets++;

                if (subcrating == half && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;
                } 
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokeTargets);
        }
    }
}
