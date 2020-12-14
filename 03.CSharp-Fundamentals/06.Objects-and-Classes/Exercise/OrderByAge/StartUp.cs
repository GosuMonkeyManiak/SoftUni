using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                string info = Console.ReadLine();
                if (info == "End")
                {
                    foreach (var item in persons.OrderBy(x => x.Age))
                    {
                        Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
                    }
                    break;
                }

                string[] infoSplit = info
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person newPerson = new Person(infoSplit[0], infoSplit[1], int.Parse(infoSplit[2]));

                persons.Add(newPerson);
            }
        }
    }
}
