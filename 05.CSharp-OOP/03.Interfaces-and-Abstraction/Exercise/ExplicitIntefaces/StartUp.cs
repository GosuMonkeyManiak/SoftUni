using System;
using ExplicitInterfaces.Contract;
using ExplicitInterfaces.Model;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                string country = parts[1];
                int age = int.Parse(parts[2]);

                Citizen citizen = new Citizen(name, country, age);

                Console.WriteLine(citizen.GetName());

                IResident citizenTwo = new Citizen(name, country, age);

                Console.WriteLine(citizenTwo.GetName());
            }
        }
    }
}
