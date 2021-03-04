using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (tokens.Length == 4) //citizen
                {
                    citizens.Add(new Citizen(name, age, tokens[2], tokens[3]));
                }
                else if (tokens.Length == 3) //rebel
                {
                    rebels.Add(new Rebel(name, age, tokens[2]));
                }
            }

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                if (citizens.Any(x => x.Name == name))
                {
                    int index = citizens.FindIndex(x => x.Name == name);
                    citizens[index].ByFood();
                }
                else if (rebels.Any(x => x.Name == name))
                {
                    int index = rebels.FindIndex(x => x.Name == name);
                    rebels[index].ByFood();
                }
            }

            int sum = citizens.Sum(x => x.Food) + rebels.Sum(x => x.Food);

            Console.WriteLine(sum);
        }
    }
}
