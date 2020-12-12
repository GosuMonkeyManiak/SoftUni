using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogic
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Stats> allHeroes = new Dictionary<string, Stats>();

            int numbersOfHerous = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfHerous; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string heroName = tokens[0];
                int hp = int.Parse(tokens[1]);
                int mp = int.Parse(tokens[2]);

                if (allHeroes.ContainsKey(heroName) == false)
                {
                    allHeroes.Add(heroName, new Stats()
                    {
                        HP = hp,
                        MP = mp
                    });
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "End")
                {
                    break;
                }

                string command = tokens[0];
                string heroName = tokens[1];

                switch (command)
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(tokens[2]);
                        string spellName = tokens[3];

                        if (allHeroes[heroName].MP >= mpNeeded)
                        {
                            allHeroes[heroName].MP -= mpNeeded;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {allHeroes[heroName].MP} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }

                        break;

                    case "TakeDamage":
                        int damage = int.Parse(tokens[2]);
                        string attacker = tokens[3];

                        allHeroes[heroName].HP -= damage;

                        if (allHeroes[heroName].HP > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {allHeroes[heroName].HP} HP left!");
                        }
                        else
                        {
                            allHeroes.Remove(heroName);
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        }

                        break;

                    case "Recharge":
                        int ammount = int.Parse(tokens[2]);

                        if (allHeroes[heroName].MP == 200)
                        {
                            Console.WriteLine($"{heroName} recharged for 0 MP!");
                        }
                        else
                        {
                            int needed = 200 - allHeroes[heroName].MP;

                            if (needed >= ammount)
                            {
                                allHeroes[heroName].MP += ammount;
                                Console.WriteLine($"{heroName} recharged for {ammount} MP!");
                            }
                            else
                            {
                                allHeroes[heroName].MP += needed;
                                Console.WriteLine($"{heroName} recharged for {needed} MP!");
                            }
                        }

                        break;

                    case "Heal":
                        int heal = int.Parse(tokens[2]);

                        if (allHeroes[heroName].HP == 100)
                        {
                            Console.WriteLine($"{heroName} healed for 0 HP!");
                        }
                        else
                        {
                            int neededHealToFull = 100 - allHeroes[heroName].HP;

                            if (neededHealToFull >= heal)
                            {
                                allHeroes[heroName].HP += heal;
                                Console.WriteLine($"{heroName} healed for {heal} HP!");
                            }
                            else
                            {
                                allHeroes[heroName].HP += neededHealToFull;
                                Console.WriteLine($"{heroName} healed for {neededHealToFull} HP!");
                            }
                        }

                        break;
                }


            }

            allHeroes = allHeroes.OrderByDescending(x => x.Value.HP)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var hero in allHeroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }
    }
}
