using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBirthdateable> peopleAndPets = new List<IBirthdateable>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "End")
                {
                    break;
                }

                if (tokens[0].ToLower() == "citizen")
                {
                    peopleAndPets.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if (tokens[0].ToLower() == "pet")
                {
                    peopleAndPets.Add(new Pet(tokens[1], tokens[2]));
                }

            }

            string birthYear = Console.ReadLine();

            peopleAndPets = peopleAndPets
                .Where(x => x.BirthDate.Substring(x.BirthDate.LastIndexOf('/') + 1) == birthYear)
                .ToList();

            foreach (var person in peopleAndPets)
            {
                Console.WriteLine(person.BirthDate);
            }

        }
    }
}
