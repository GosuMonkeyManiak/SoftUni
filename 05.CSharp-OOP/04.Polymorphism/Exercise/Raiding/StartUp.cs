using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Models;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> raidGroup = new List<BaseHero>();

            int line = 0;

            while (line != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType.ToLower())
                {
                    case "druid":
                        raidGroup.Add(new Druid(heroName));
                        break;

                    case "paladin":
                        raidGroup.Add(new Paladin(heroName));
                        break;

                    case "rogue":
                        raidGroup.Add(new Rogue(heroName));
                        break;

                    case "warrior":
                        raidGroup.Add(new Warrior(heroName));
                        break;

                    default:
                        Console.WriteLine("Invalid hero!");
                        continue;
                }

                line++;
            }

            int bossHealth = int.Parse(Console.ReadLine());

            foreach (var baseHero in raidGroup)
            {
                baseHero.CastAbility();
            }


            int allPower = raidGroup.Sum(x => x.Power);


            if (allPower >= bossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
