using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> allTrainers = new Dictionary<string, Trainer>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Tournament")
                {
                    break;
                }

                if (tokens.Length == 4)
                {
                    string trainerName = tokens[0];
                    string pokemonName = tokens[1];
                    string element = tokens[2];
                    int health = int.Parse(tokens[3]);

                    Pokemon pokemon = new Pokemon(pokemonName, element, health);

                    if (!allTrainers.ContainsKey(trainerName))
                    {
                        Trainer trainer = new Trainer(trainerName);
                        trainer.Pokemons.Add(pokemon);

                        allTrainers.Add(trainerName, trainer);
                        continue;
                    }

                    allTrainers[trainerName].Pokemons.Add(pokemon);
                    
                }

            }


            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                GiveBadgeOrReduceHealth(allTrainers, command);
            }

            allTrainers = allTrainers
                .OrderByDescending(x => x.Value.Badges)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var trainer in allTrainers.Values)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }

        }

        static void GiveBadgeOrReduceHealth(Dictionary<string, Trainer> trainers, string element)
        {
            trainers
                .Where(x => CheckElement(x, element))
                .ToList();
        }

        static bool CheckElement(KeyValuePair<string, Trainer> trainer, string element)
        {
            foreach (var pokemon in trainer.Value.Pokemons)
            {
                if (pokemon.Element == element)
                {
                    trainer.Value.Badges++;
                    return true;
                }
            }

            //reduce health by 10
            for (int i = 0; i < trainer.Value.Pokemons.Count; i++)
            {
                trainer.Value.Pokemons[i].Health -= 10;
                if (trainer.Value.Pokemons[i].Health <= 0)
                {
                    trainer.Value.Pokemons.RemoveAt(i);
                    i--;
                }
            }

            return false;
        }

    }
}
