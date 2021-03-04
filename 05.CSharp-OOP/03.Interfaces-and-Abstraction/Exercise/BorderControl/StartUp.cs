using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> allCitizens = new List<IIdentifiable>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "End")
                {
                    break;
                }

                if (tokens.Length == 3) //citizens
                {
                    allCitizens.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));    
                }
                else if(tokens.Length == 2) //robot
                {
                    allCitizens.Add(new Robot(tokens[0], tokens[1]));
                }

            }

            string fakeIdNumbers = Console.ReadLine();

            allCitizens = allCitizens
                .Where(x => x.Id.Substring(x.Id.Length - fakeIdNumbers.Length) == fakeIdNumbers)
                .ToList();

            foreach (var citizen in allCitizens)
            {
                Console.WriteLine(citizen.Id);
            }

        }
    }
}
