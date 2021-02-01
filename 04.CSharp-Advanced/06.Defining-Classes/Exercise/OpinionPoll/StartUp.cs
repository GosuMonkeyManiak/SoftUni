using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person currentPerson = new Person(name, age);

                people.Add(currentPerson);
            }

            people = people
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
